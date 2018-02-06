using ABADiversityClient.LogicalControllers;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/HighCompensatedPartners")]
  public class HighCompensatedPartnersController : Controller
  {
    // GET: api/HighCompensatedPartners
    private ApiAccess _webApiAccess;
    public HighCompensatedPartnersController()
    {
      _webApiAccess = new ApiAccess("HighCompensatedPartners");
    }

    [HttpGet]
    public async Task<HighCompensatedPartners[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<HighCompensatedPartners[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<HighCompensatedPartners> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<HighCompensatedPartners>(result.ToString());
    }

    [HttpPost]
    public async Task<HighCompensatedPartners> Post([FromBody]HighCompensatedPartners body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<HighCompensatedPartners>(result.ToString());
    }

    [HttpPut("{id}")]
    public async Task<HighCompensatedPartners> Put(int id, [FromBody]HighCompensatedPartners body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<HighCompensatedPartners>(result.ToString());
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
