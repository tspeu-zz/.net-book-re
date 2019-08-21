using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi_FreeCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
  
    public class SalidaController : Controller
    {
        // GET: api/Salida
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Salida/5
        [HttpGet("{id}", Name = "GetSalida")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Salida
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Salida/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
