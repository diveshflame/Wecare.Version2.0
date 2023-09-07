using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WeCare.Data.Data.Doctor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wecare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDoctorController : ControllerBase
    {
        // GET: api/<AddDoctorController>
    

        //Arjun changes
        private readonly IAddDoctorData _db;

        public AddDoctorController(IAddDoctorData db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> AddDoctor()
        {
            try
            {
                var data = await _db.GetDep();



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

        //Arjun changes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddDoctorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddDoctorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AddDoctorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddDoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
