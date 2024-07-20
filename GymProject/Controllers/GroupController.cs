using DAL.DTO;
using DAL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;
using System.Net;

namespace GymProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroup _group;
        public GroupController(IGroup group)
        {
            _group = group;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public List<GroupDto> Get()
        {
            List<GroupDto> result = _group.getAllGroups();
            return result;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var (status, group) = _group.getGroupById(id);
            if (group == null)
            {
                return NotFound(status);
            }
            return Ok(new { Status = status, group = group });
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] GroupDto group)
        {
            Console.WriteLine("נכנסת?????????");
            var res = _group.addGroup(group);
            if (res)
                return Ok();
            return BadRequest();
        }

        [HttpPost("/addUser{id}")]
        public void Post([FromBody] User user, int id)
        {
            _group.addUserToGroup(user, id);
        }

        // PUT api/<BooksController>/5
        [HttpPut]
        public void Put(GroupDto group)
        {
            _group.updateGroup(group);
        }

        //DELETE api/<BooksController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            _group.removeGroup(id);
        }
        [HttpDelete("/removeUser{id}")]
        public void Delete(User user, int id)
        {
            _group.removeUserFromGroup(user, id);
        }

    }
}

