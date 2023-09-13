using Microsoft.AspNetCore.Mvc;
using Wecare.Data.Data.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wecare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewAppointmentController : ControllerBase
    {
        private readonly IViewAppointmentData _db;

        public ViewAppointmentController(IViewAppointmentData db)
        {
            _db = db;
        }
        // GET: api/<ViewAppointmentController>
        [HttpGet]
        
            public async Task<IActionResult> Get()
            {
                try
                {
                    var data = await _db.GetPatientTodayAppointment();

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

            

        // GET api/<ViewAppointmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ViewAppointmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            int DocId = 1001;
            DateTime StartTime = DateTime.Parse("2023 - 09 - 13 11:30:00");
            DateTime EndTime = DateTime.Parse("2023 - 09 - 13 12:30:00");
             _db.InsertIntoDocAvailability( DocId, StartTime, EndTime);
        }

        // PUT api/<ViewAppointmentController>/5
        [HttpPut]
        public void Put([FromBody] string value)
        {
            int AppointmentId = 3003;
            DateTime DateTimeNow = DateTime.Now;
            _db.UpdateAppointmentTable(AppointmentId, DateTimeNow);
        }

        // DELETE api/<ViewAppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
