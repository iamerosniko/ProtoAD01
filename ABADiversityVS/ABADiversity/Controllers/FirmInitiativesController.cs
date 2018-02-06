using ABADiversityClient.LogicalControllers;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/FirmInitiatives")]
  public class FirmInitiativesController : Controller
  {
    private ApiAccess _webApiAccess;
    public FirmInitiativesController()
    {
      _webApiAccess = new ApiAccess("FirmInitiatives");
    }

    [HttpGet]
    public async Task<FirmInitiatives[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<FirmInitiatives[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<FirmInitiatives> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<FirmInitiatives>(result.ToString());
    }

    [HttpPost]
    public async Task<FirmInitiatives> Post([FromBody]FirmInitiatives body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<FirmInitiatives>(result.ToString());
    }

    [HttpPut("{id}")]
    public async Task<FirmInitiatives> Put(int id, [FromBody]FirmInitiatives body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<FirmInitiatives>(result.ToString());
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
