using ABADiversityClient.Entities;
using ABADiversityClient.LogicalControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/FirmLeaderships")]
  public class FirmLeadershipsController : Controller
  {
    // GET: api/FirmLeaderships
    private ApiAccess _webApiAccess;
    public FirmLeadershipsController()
    {
      _webApiAccess = new ApiAccess("FirmLeaderships");
    }

    [HttpGet]
    public async Task<FirmLeaderships[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<FirmLeaderships[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<FirmLeaderships> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<FirmLeaderships>(result.ToString());
    }

    [HttpPost]
    public async Task<FirmLeaderships> Post([FromBody]FirmLeaderships body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<FirmLeaderships>(result.ToString());
    }

    [HttpPut("{id}")]
    public async Task<FirmLeaderships> Put(int id, [FromBody]FirmLeaderships body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<FirmLeaderships>(result.ToString());
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
