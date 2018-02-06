using ABADiversityClient.LogicalControllers;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/FirmDemographics")]
  public class FirmDemographicsController : Controller
  {
    private ApiAccess _webApiAccess;
    public FirmDemographicsController()
    {
      _webApiAccess = new ApiAccess("FirmDemographics");
    }

    [HttpGet]
    public async Task<FirmDemographics[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<FirmDemographics[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<FirmDemographics> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<FirmDemographics>(result.ToString());
    }

    [HttpPost]
    public async Task<FirmDemographics> Post([FromBody]FirmDemographics body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<FirmDemographics>(result.ToString());
    }

    [HttpPut("{id}")]
    public async Task<FirmDemographics> Put(int id, [FromBody]FirmDemographics body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<FirmDemographics>(result.ToString());
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
