using ABADiversityClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.LogicalControllers
{
  [Produces("application/json")]
  [Route("api/SetUserAccesses")]
  public class SetUserAccessesController : Controller
  {
    private ApiAccess _webApiAccess;

    public SetUserAccessesController()
    {
      _webApiAccess = new ApiAccess("SetUserAccesses");
    }
    // GET: api/SetUserAccesses
    [HttpGet]
    public async Task<SetUserAccess[]> Get()
    {
      //_webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<SetUserAccess[]>(result.ToString());
    }

    // GET: api/SetUserAccesses/5
    [HttpGet("{id}")]
    public async Task<SetUserAccess> Get(int id)
    {
      //_webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<SetUserAccess>(result.ToString());
    }

  }
}
