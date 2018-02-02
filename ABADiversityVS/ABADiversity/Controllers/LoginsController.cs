using ABADiversity;
using ABADiversityClient.LogicalControllers;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  public class LoginsController : Controller
  {
    private Users _user;
    private object currentUserController;

    public LoginsController()
    {
      _user = new Users();
    }
    // GET: api/MyToken
    [HttpGet]

    [Route("api/ProvideAuthenticationToken")]
    public MyToken ProvideAuthenticationToken()
    {
      //getCurrentUser
      var currentUser = _user.GetCurrentUser();

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.Configuration["IDPServer:IssuerSigningKey"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var token = new JwtSecurityToken(
         claims: _user.getCurrentClaims(currentUser),
         signingCredentials: creds
      );


      var myToken = new JwtSecurityTokenHandler().WriteToken(token);

      HttpContext.Session.SetString("AuthToken", myToken);

      return new MyToken
      {
        Token = "myToken",
        TokenName = "AuthToken"
      };
    }


    [HttpGet]

    [Route("api/ProvideAuthorizationToken")]
    public MyToken ProvideAuthorizationToken()
    {
      return new MyToken
      {
        Token = "agaga",
        TokenName = "asd"
      };
    }

    [HttpGet]

    [Route("api/GetCurrentToken")]
    public string GetCurrentToken()
    {
      var AuthToken = HttpContext.Session.GetString("AuthToken");
      return AuthToken;
    }


  }
}
