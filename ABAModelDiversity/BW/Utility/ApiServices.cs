using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BW.Utility
{
  public class ApiServices : Controller
  {
    private ApiAccess _api;
    public ApiServices(string controller, string authorizationToken)
    {
      _api = new ApiAccess(controller);
      _api.AssignAuthorization(authorizationToken);
    }

    public async Task<string> Get()
    {
      var result = await _api.GetRequest();
      return result;
    }

    public async Task<string> Get(string id)
    {
      var result = await _api.GetRequest(id);
      return result;
    }

    public async Task<string> Post(string body)
    {
      var result = await _api.PostRequest(body);
      return result;
    }

    public async Task<string> Put(string id, string body)
    {
      var result = await _api.PutRequest(id, body);
      return result;
    }

    public async Task<string> Delete(string id)
    {
      var result = await _api.DeleteRequest(id);
      return result;
    }
  }
}
