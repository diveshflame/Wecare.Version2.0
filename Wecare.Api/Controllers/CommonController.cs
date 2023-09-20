using Microsoft.AspNetCore.Mvc;
using Wecare.Data.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wecare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonFunctions dbAccess;
        public CommonController(ICommonFunctions _dbAccess)
        {
            dbAccess = _dbAccess;

        }
        // GET: api/<CommonController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await dbAccess.GetDepartmentName();
            return Ok(data);
        }

        // GET api/<CommonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
