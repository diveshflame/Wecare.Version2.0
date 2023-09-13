using Microsoft.AspNetCore.Mvc;
using Wecare.Data.Data.Interface;
using WeCare.Data.Data.Doctor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wecare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        //Arjun changes
        private readonly IBookAppointmentData _db;

        public AppointmentController(IBookAppointmentData db)
        {
            _db = db;
        }
        // GET: api/<AppointmentController>
        [HttpGet]
        
            public async Task<IActionResult> Get()
            {
            string test = "ENT";
                try
                {
                    var data = await _db.GetDoctorNames(test);



                    if (data != null)
                    {

                        return Ok(data);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
