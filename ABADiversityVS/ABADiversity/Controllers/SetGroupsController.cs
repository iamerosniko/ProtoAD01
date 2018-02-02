using ABADiversityClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.LogicalControllers
{
  [Produces("application/json")]
  [Route("api/SetGroups")]
  public class SetGroupsController : Controller
  {
    // GET: api/SetGroups
    private ApiAccess _webApiAccess;

    public SetGroupsController()
    {
      _webApiAccess = new ApiAccess("SetGroups");
    }

    [HttpGet]
    public async Task<SetGroup[]> Get()
    {
      //_webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<SetGroup[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<SetGroup> Get(string id)
    {
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<SetGroup>(result.ToString());
    }
  }
}
