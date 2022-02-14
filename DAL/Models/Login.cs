using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndTime { get; set; }
    }
    public class LoginDto
    {
        [FromHeader]
        public string UserName { get; set; }
        [FromHeader]
        public string Password { get; set; }
    }
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpiraitonDate { get; set; }
        public string RefreshToken { get; set; }
    }
    public class APIAuthority
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
