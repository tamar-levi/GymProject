using DAL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MODELS.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
public struct Login
{
    public string mail { get; set; }
    public string password { get; set; }

    public Login(string Mail, string Password)
    {
        mail = Mail;
        password = Password;
    }
}

namespace GymProject.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
       
        private IConfiguration _config;
        private readonly IUser _user;
        public LoginController(IConfiguration config,IUser user)
        {
            _config = config;
            _user = user;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Login loginRequest)
        {
            //בדיקת סיסמא של משתמש
            var userFind= _user.getByMail(loginRequest.mail);
            if (userFind.afterMapper != null && userFind.afterMapper.password == loginRequest.password)
            {


                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);


                return Ok(token);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}