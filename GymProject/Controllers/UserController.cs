using Microsoft.AspNetCore.Mvc;

using DAL.DTO;
using DAL.Interface;
using MODELS.Models;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace GymProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        // GET: api/<BooksController>
      
        [HttpGet]
        public List<UserDto> Get()
        {
            // _user.getAllBooks();
            List<UserDto> result = _user.getAllUsers();
            return result;
        }

        // GET api/<BooksController>/5
        [HttpGet("GetById/{mail}")]
        public IActionResult Get(string mail)
        {
            var (status, user) = _user.getByMail(mail);
            if (user == null)
            {
                return NotFound(status);
            }
            return Ok(new { Status = status, User = user });
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] UserDto user)
        {
            var res = _user.createUser(user);
            if (res)
                return Ok();
            return BadRequest();
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _user.deleteUser(id);
        }



    }
}


