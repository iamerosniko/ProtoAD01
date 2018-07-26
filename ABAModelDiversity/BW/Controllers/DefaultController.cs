using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BW.Controllers
{
  [Produces("application/json")]
  [Route("api/Default")]
  public class DefaultController : Controller
  {

    private string _apiURL;
    private HttpClient _client;
    // GET: api/Default
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/Default/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<string> Get(int id)
    {
      _apiURL = "http://localhost:63992/api/default";
      _client = new HttpClient();

      try
      {
        var request = await _client.GetAsync(_apiURL);
        if (request.IsSuccessStatusCode)
        {
          var result = await request.Content.ReadAsStringAsync();
          return result;
        }

        return null;
      }
      catch
      {
        return null;
      }
    }

    // POST: api/Default
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Default/5
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
