using ABADiversityClient.LogicalControllers;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/JoinedLawyers")]
  public class JoinedLawyersController : Controller
  {
    private ApiAccess _webApiAccess;
    public JoinedLawyersController()
    {
      _webApiAccess = new ApiAccess("JoinedLawyers");
    }

    [HttpGet]
    public async Task<JoinedLawyers[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<JoinedLawyers[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<JoinedLawyers> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<JoinedLawyers>(result.ToString());
    }

    [HttpPost]
    public async Task<JoinedLawyers> Post([FromBody]JoinedLawyers body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<JoinedLawyers>(result.ToString());
    }

    [HttpPut("{id}")]
    public async Task<JoinedLawyers> Put(int id, [FromBody]JoinedLawyers body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<JoinedLawyers>(result.ToString());
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
