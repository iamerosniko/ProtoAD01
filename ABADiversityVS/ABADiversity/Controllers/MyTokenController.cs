using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABADiversityClient.Controllers
{

    public class MyToken{
      public string TokenName { get; set; }
      public string Token { get; set; }
    }
    [Produces("application/json")]
    [Route("api/MyToken")]
    public class MyTokenController : Controller
    {
        // GET: api/MyToken
        [HttpGet]
        public MyToken Get()
        {
      return new MyToken
      {
        Token = "agaga",
        TokenName = "asd"
      };
        }

        // GET: api/MyToken/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/MyToken
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/MyToken/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
