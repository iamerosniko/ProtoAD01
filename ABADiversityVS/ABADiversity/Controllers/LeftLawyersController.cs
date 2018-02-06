using ABADiversityClient.Entities;
using ABADiversityClient.LogicalControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/LeftLawyers")]
  public class LeftLawyersController : Controller
  {
    private ApiAccess _webApiAccess;
    public LeftLawyersController()
    {
      _webApiAccess = new ApiAccess("LeftLawyers");
    }

    [HttpGet]
    public async Task<LeftLawyers[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<LeftLawyers[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<LeftLawyers> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<LeftLawyers>(result.ToString());
    }

    [HttpPost]
    public async Task<LeftLawyers> Post([FromBody]LeftLawyers body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<LeftLawyers>(result.ToString());
    }

    [HttpPut("{id}")]
    public async Task<LeftLawyers> Put(int id, [FromBody]LeftLawyers body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<LeftLawyers>(result.ToString());
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
