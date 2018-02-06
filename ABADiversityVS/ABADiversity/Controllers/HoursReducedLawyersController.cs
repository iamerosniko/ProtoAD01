using ABADiversityClient.LogicalControllers;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/HoursReducedLawyers")]
  public class HoursReducedLawyersController : Controller
  {
    private ApiAccess _webApiAccess;
    public HoursReducedLawyersController()
    {
      _webApiAccess = new ApiAccess("HoursReducedLawyers");
    }

    [HttpGet]
    public async Task<HoursReducedLawyers[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<HoursReducedLawyers[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<HoursReducedLawyers> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<HoursReducedLawyers>(result.ToString());
    }

    [HttpPost]
    public async Task<HoursReducedLawyers> Post([FromBody]HoursReducedLawyers body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<HoursReducedLawyers>(result.ToString());
    }

    [HttpPut("{id}")]
    public async Task<HoursReducedLawyers> Put(int id, [FromBody]HoursReducedLawyers body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<HoursReducedLawyers>(result.ToString());
    }

    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));

      var result = await _webApiAccess.DeleteRequest(id.ToString());
      return result;
    }
  }
}
