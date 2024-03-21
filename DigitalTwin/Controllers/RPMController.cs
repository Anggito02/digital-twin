using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalTwin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RPMController : ControllerBase
    {
        // GET: api/<RPMController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RPMController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RPMController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RPMController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RPMController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
