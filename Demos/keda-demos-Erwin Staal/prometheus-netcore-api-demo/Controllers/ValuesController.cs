using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prometheus;
using Prometheus.Client;

namespace CoreWebHttpRequestDurations.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        Summary summary = Metrics.CreateSummary("myapp_order_value_usd", "Received order values (in USD). text");
        readonly Counter _counter = Metrics.CreateCounter("myCounter", "some help about this");

        Random rnd = new Random();
      
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _counter.Inc();

            summary.Observe(rnd.Next(1, 1000));
            
            return new string[] {"value1", "value2"};
        }

        [HttpGet("{id}")]
        public IEnumerable<string> Get(int id)
        {
            return new string[]
            {
                $"value1_{id}", $"value2_{id}"
            };
        }
        

        [HttpGet("long")]
        public IEnumerable<string> GetLong()
        {
            _counter.Inc();

            summary.Observe(rnd.Next(1, 1000));
            
            Thread.Sleep(2000);
            return new string[] {"long", "long"};
        }
        
        [HttpGet("err")]
        public IEnumerable<string> Get500()
        {
            throw new Exception("some");
        }
        
        [HttpGet("bad")]
        public IActionResult Get400()
        {
            return BadRequest();
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Thread.Sleep(500);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
