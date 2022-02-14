using DAL;
using DAL.Models;
using ExecutiveOperations.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Homeworks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Login login = new Login();
        private readonly IConfiguration _configuraiton;
        public ExecutiveRepository repository = new ExecutiveRepository();
        public TokenHandler tokenHandler = new TokenHandler();

        public AuthController(IConfiguration configuraiton)
        {
            _configuraiton = configuraiton;
        }

        [HttpPost("create")]
        public async Task<IActionResult> authorCreate(User author)
        {
            try
            {
                author.Password = PasswordCrypto(author.Password);
                repository.CreateUser(author);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Hata Oluştu" + ex.Message);
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromHeader] LoginDto loginDto)
        {
            try
            {

                User loginUser = new User();
                loginUser.UserName = loginDto.UserName;
                loginUser.Password = PasswordCrypto(loginDto.Password);
                var result = repository.GetAuthUser(loginUser);
                if (result != null)
                {
                    return (tokenHandler.CreateAccessToken(login).ToString());
                }
                else
                {
                    return BadRequest("Kullanıcı adı veya şifre yanlış");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Hata Oluştu" + ex.Message);
            }
        }


        public string PasswordCrypto(string password)
        {
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();

            byte[] array = Encoding.UTF8.GetBytes(password);

            array = mD5.ComputeHash(array);

            StringBuilder stringBuilder = new StringBuilder();


            foreach (byte item in array)
            {
                stringBuilder.Append(item.ToString("x2").ToLower());
            }

            return stringBuilder.ToString();
        }
    }
}
