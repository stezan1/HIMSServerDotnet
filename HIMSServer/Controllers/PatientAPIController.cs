using PatientLibrary;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HIMSServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        // GET: api/<PatientAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PatientAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Patient value)
        {
            value.name = value.name.ToUpper();
            if (value.age > 200)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                    , "Age must be less than or equal to 200");
            }

            PatientDbContext p=new PatientDbContext();
            p.Patients.Add(value); //add in memory
            p.SaveChanges();    //commit to physical server

            return Ok(value);
        }

        // PUT api/<PatientAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
