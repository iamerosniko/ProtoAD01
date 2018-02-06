using ABADiversityClient.LogicalControllers;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/CompanyProfiles")]
  public class CompanyProfilesController : Controller
  {
    private ApiAccess _webApiAccess;

    public CompanyProfilesController()
    {
      _webApiAccess = new ApiAccess("CompanyProfiles");
    }
    [HttpGet]
    public async Task<CompanyProfiles[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<CompanyProfiles[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<CompanyProfiles> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<CompanyProfiles>(result.ToString());
    }

    [HttpPost]
    public async Task<CompanyProfiles> Post([FromBody]CompanyProfiles body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<CompanyProfiles>(result.ToString());
    }


    [HttpPut("{id}")]
    public async Task<CompanyProfiles> Put(int id, [FromBody]CompanyProfiles body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<CompanyProfiles>(result.ToString());
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
