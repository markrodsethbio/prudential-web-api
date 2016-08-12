using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prudential.Infrastructure;
using Prudential.Core;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Prudential.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PrudentialController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            PrudentialClientRepository repository = new PrudentialClientRepository();
            var client = repository.GetClient(30000047);

            string json = JsonConvert.SerializeObject(client, Formatting.Indented);

            return json;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
