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
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : Controller
    {

        private readonly IManager _manager;
        public ManagerController(IManager manager)
        {
            _manager = manager;
        }
        

        [HttpGet]
        public List<ManagerDto> Get()
        {
           
            List<ManagerDto> result = _manager.getAllManager();
            return result;
        }

       
   

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] ManagerDto manager)
        {
            var res = _manager.addManager(manager);
            if (res)
                return Ok();
            return BadRequest();
        }

 

    }
}


