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
    public class SchedulesController : Controller
    {

        private readonly ISchedules _schedules;
        public SchedulesController(ISchedules schedules)
        {
            _schedules = schedules;
        }
        [HttpGet]
        public List<ScheduleDto> Get()
        {
            List<ScheduleDto> result = _schedules.getAllSchedules();
            return result;
        }
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
        [HttpPost]
        public ActionResult Post([FromBody] ScheduleDto schedules)
        {
            var res = _schedules.addSchedules(schedules);
            if (res)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public void Put([FromBody] ScheduleDto schedule)
        {
            _schedules.updateSchedule(schedule);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _schedules.removeSchedules(id);
        }

    }
}
