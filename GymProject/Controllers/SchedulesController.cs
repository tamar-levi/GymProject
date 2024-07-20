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
    public class SchedulesController : Controller
    {
        
            private readonly ISchedules _schedules;
            public SchedulesController(ISchedules schedules)
            {
            _schedules = schedules;
            }
        // GET: api/<BooksController>
        [HttpGet]
        public List<ScheduleDto> Get()
        {
            // _user.getAllBooks();
            List<ScheduleDto> result = _schedules.getAllSchedules();
            return result;
            //return Ok();
        }

        // GET api/<BooksController>/5
        [HttpGet("GetByDate/{id}")]
            public IActionResult Get(DateTime date)
            {
              var (status, schedules) = _schedules.getSchedulesByDate(date);
              if (schedules == null)
              {
                 return NotFound(status);
              }
              return Ok(new { Status = status, Schedules = schedules });
            }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] ScheduleDto schedules)
        {
            var res = _schedules.addSchedules(schedules);
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
              _schedules.removeSchedules(id);
            }

        
    }
}
