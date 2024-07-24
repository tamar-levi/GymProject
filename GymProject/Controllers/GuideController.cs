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
    public class GuideController : Controller
    {
        private readonly IGuide _guide;
        public GuideController(IGuide guide)
        {
            _guide = guide;
        }
        [HttpGet]
        public List<GuidDto> Get()
        {
            List<GuidDto> result = _guide.getAllGuides();
            return result;
        }

        [HttpGet("getByName/{name}")]
        public IActionResult Get(string name)
        {
            var (status, guideName) = _guide.getGuidesByName(name);
            if (guideName == null)
            {
                return NotFound(status);
            }
            return Ok(new { Status = status, GuideName = guideName });
        }
        [HttpPost]
        public ActionResult Post([FromBody] GuidDto guide)
        {
            var res = _guide.addGuide(guide);
            if (res)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public void Put( [FromBody] GuidDto value)
        {
            _guide.updateGuide(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _guide.removeGuide(id);
        }

    }
}

