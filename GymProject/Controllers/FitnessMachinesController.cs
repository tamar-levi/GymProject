using DAL.Interface;
using DAL.DTO;
using Microsoft.AspNetCore.Mvc;
using MODELS.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GymProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessMachinesController : Controller
    {
        private readonly IFitnessMachines _fitnessMachines;
        public FitnessMachinesController(IFitnessMachines fitnessMachines)
        {
            _fitnessMachines = fitnessMachines;
        }
        // GET: api/<BooksController>
      
        [HttpGet]
        public List<FitnesMachinesDto> Get()
        {
            List<FitnesMachinesDto> result=_fitnessMachines.getAllFitnessMachines();
            return result;
            //return Ok();
        }

        // GET api/<BooksController>
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
            
        //    return "value";
        //}
        [HttpGet("byAddress/{address}")]
        public IActionResult Get(string address)
        {
            Console.WriteLine("נכנס");
            var (status, fitnessMachine) = _fitnessMachines.getFitnessMachinesByArea(address);
            if (fitnessMachine == null)
            {
                return NotFound(status);
            }
            return Ok(new { Status = status, FitnessMachine = fitnessMachine });
        }
        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] FitnesMachinesDto fitnessMachines)
        {
          
            var res = _fitnessMachines.addFitnessMachines(fitnessMachines);
            if (res)
               return Ok();
            return BadRequest();
        }

        // PUT api/<BooksController>
        [HttpPut]
        public ActionResult Put([FromBody] FitnesMachinesDto fitnesMachinesDto)
        {
            var res=_fitnessMachines.updateFitnessMachines(fitnesMachinesDto);
            if (res)
                return Ok();
            return BadRequest();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _fitnessMachines.removeFitnessMachines(id);
        }

    }
}

