using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_FreeCodeCamp.Domain.Models;

namespace webapi_FreeCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class BillingController : ControllerBase
    {
        // GET: api/Billing
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Billing/5
        [HttpGet("{id}", Name = "GetBilling")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Billing
        [HttpPost]
        public string Post([FromBody]  InputData value) {  
       
            return "value de posty - OK" ;
        }

        // PUT: api/Billing/5
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
