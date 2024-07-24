using DAL.DTO;
using DAL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using MODELS.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

public struct Register
{
    public string mail { get; set; }
    public string password { get; set; }
    public string name { get; set; }
    public string address { get; set; }

    public Register(string Mail, string Password, string Name, string Address)
    {
        mail = Mail;
        password = Password;
        name = Name;
        address = Address;
    }
}

namespace GymProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AALoginController : Controller
    {
        private IConfiguration _config;
        private readonly IUser _user;
        private readonly IManager _manager;

        public AALoginController(IConfiguration config, IUser user, IManager manager)
        {
            _config = config;
            _user = user;
            _manager = manager;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Login loginRequest)
        {
            // Checking user password
            var userFind = _user.getByMail(loginRequest.mail);

            if (userFind.afterMapper == null)
            {
                return BadRequest("User not found");
            }

            // Checking for manager
            var ManagerFind = _manager.getAllManager().FirstOrDefault(x => x.userId == userFind.afterMapper.Id);

            if (userFind.afterMapper.password == loginRequest.password)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                string role = "User";
                if (ManagerFind != null)
                    role = "Admin";

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, loginRequest.mail),
                    new Claim("role", role) // Admin role
                };

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid password");
            }
        }

        [HttpPost("add new manager for first visit")]
        public IActionResult Register([FromBody] Register registerRequest)
        {
            // Checking if there are already managers in the system
            if (_manager.getAllManager().Count() > 0)
            {
                return BadRequest("Admin already exists");
            }

            // Creating a new user
            UserDto newUser = new UserDto
            {
                mail = registerRequest.mail,
                password = registerRequest.password,
                address = registerRequest.address,
                Name = registerRequest.name
            };

            _user.createUser(newUser);

            // Creating a new manager
            var newManager = new ManagerDto
            {
                userId = newUser.Id
            };

            _manager.addManager(newManager);

            return Ok("Admin registered successfully");
        }
    }
}
