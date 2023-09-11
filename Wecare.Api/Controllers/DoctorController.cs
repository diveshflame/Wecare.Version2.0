using Microsoft.AspNetCore.Mvc;
using WeCare.Data.Data.Doctor;
using WeCare.Data.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wecare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorData dbAccess;
        public DoctorController(IDoctorData _dbAccess)
        {
            dbAccess = _dbAccess;

        }
        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int DocId = 1001;
            var data = await dbAccess.CheckDocAvailability(DocId);


            return Ok(data);

        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DoctorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] int did,int ddid)
        {
            int DocId = 1002;
            int DeptId = 502;
            dbAccess.UpdateDoc(DocId, DeptId);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
