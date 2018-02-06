using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/Reports")]
  public class ReportsController : Controller
  {
    // GET: api/Reports
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/Reports/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Reports
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Reports/5
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
