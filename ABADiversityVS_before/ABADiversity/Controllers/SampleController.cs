using ABADiversityAPI.Controllers;
using ABADiversityAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/Sample")]
  public class SampleController : Controller
  {
    private readonly ABAContext _context;
    // GET: api/Sample
    //public SampleController(ABAContext context)
    //{
    //  _context = context;
    //}

    [HttpGet]
    public IEnumerable<CompanyProfiles> Get()
    {

      CompanyProfilesController a = new CompanyProfilesController(_context);
      return a.GetCompanyProfiles();
    }

    // GET: api/Sample/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Sample
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Sample/5
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
