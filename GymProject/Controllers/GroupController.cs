using DAL.DTO;
using DAL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;
using System.Net;

namespace GymProject.Controllers
{
    [Authorize(Roles = "Admin")]

    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroup _group;
        public GroupController(IGroup group)
        {
            _group = group;
        }
        [HttpGet]
        public List<GroupDto> Get()
        {
            List<GroupDto> result = _group.getAllGroups();
            return result;
        }

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

        [HttpPost]
        public ActionResult Post([FromBody] GroupDto group)
        {
            var res = _group.addGroup(group);
            if (res)
                return Ok();
            return BadRequest();
        }

        [HttpPost("/addUser{id}")]
        public void Post( int userId, int id)
        {
            _group.addUserToGroup(userId, id);
        }

        [HttpPut]
        public void Put(GroupDto group)
        {
            _group.updateGroup(group);
        }
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

