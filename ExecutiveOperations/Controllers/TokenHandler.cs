using DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Homeworks.Controllers
{
    public class TokenHandler
    {
        public Token CreateAccessToken(Login user)
        {
            Token token = new Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Token"));

            SigningCredentials singingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpiraitonDate = DateTime.Now.AddMinutes(2);
            JwtSecurityToken securityToken = new JwtSecurityToken
            (
                issuer: "www.myapi.com",
                audience: "www.cc.com",
                expires: token.ExpiraitonDate,
                notBefore: DateTime.Now,
                signingCredentials: singingCredentials
           );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using(RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
