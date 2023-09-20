using Microsoft.AspNetCore.Mvc;
using Wecare.Data.Data.Common;
using WeCare.Data.Data.Doctor;
using WeCare.Data.DataAccess;
using Wecare.Data.Data.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wecare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ICommonFunctions dbAccess;
        public DoctorController(ICommonFunctions _dbAccess)
        {
            dbAccess = _dbAccess;

        }
        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            var data = await dbAccess.GetDoctorName();
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
        public void Put([FromBody] int did, int ddid)
        {
            int DocId = 1002;
            int DeptId = 502;
           /* dbAccess.UpdateDoc(DocId, DeptId);*/
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
