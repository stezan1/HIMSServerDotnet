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
            
            PatientDbContext p = new PatientDbContext();
            //return all data
         return new string[] { "value1", "value2" };

        }

        // GET api/<PatientAPIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PatientDbContext p = new PatientDbContext();

            //check if patient exist
            var patient = p.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
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
        public IActionResult Put(int id, [FromBody] Patient updatedPatient)
        {
            PatientDbContext p = new PatientDbContext();
            var patient = p.Patients.Find(id);
                if (patient == null)
                {
                    return NotFound();
                }

                // updating code to db
                patient.name = updatedPatient.name;
                patient.code = updatedPatient.code;
                patient.age = updatedPatient.age;

                p.SaveChanges();
            

            return Ok(updatedPatient);

        }

        // DELETE api/<PatientAPIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PatientDbContext p = new PatientDbContext();
            //check if patient exist
            var patient =p.Patients.Find(id);
                if (patient == null)
                {
                    return NotFound();
                }
                //delete the patient
                p.Patients.Remove(patient);
                p.SaveChanges();
            
            return Ok(id+" patient id is deleted");
        }
    }
}
