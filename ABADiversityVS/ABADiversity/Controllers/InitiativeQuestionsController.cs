using ABADiversityClient.Entities;
using ABADiversityClient.LogicalControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/InitiativeQuestions")]
  public class InitiativeQuestionsController : Controller
  {
    private ApiAccess _webApiAccess;
    public InitiativeQuestionsController()
    {
      _webApiAccess = new ApiAccess("InitiativeQuestions");
    }

    [HttpGet]
    public async Task<InitiativeQuestions[]> Get()
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest();
      return JsonConvert.DeserializeObject<InitiativeQuestions[]>(result.ToString());
    }

    [HttpGet("{id}")]
    public async Task<InitiativeQuestions> Get(int id)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var result = await _webApiAccess.GetRequest(id.ToString());
      return JsonConvert.DeserializeObject<InitiativeQuestions>(result.ToString());
    }

    [HttpPost]
    public async Task<InitiativeQuestions> Post([FromBody]InitiativeQuestions body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PostRequest(content);
      return JsonConvert.DeserializeObject<InitiativeQuestions>(result.ToString());
    }

    [HttpPut("{id}")]
    public async Task<InitiativeQuestions> Put(int id, [FromBody]InitiativeQuestions body)
    {
      _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
      var content = JsonConvert.SerializeObject(body);

      var result = await _webApiAccess.PutRequest(id.ToString(), content);
      return JsonConvert.DeserializeObject<InitiativeQuestions>(result.ToString());
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
