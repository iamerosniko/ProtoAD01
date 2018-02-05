using ABADiversity;
using ABADiversityClient.LogicalControllers;
using ABADiversityClient.LogicalModels;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  public class LoginsController : Controller
  {
    private Users _user;
    private TokenFactory _tokenFactory;

    public LoginsController()
    {
      _user = new Users();
      _tokenFactory = new TokenFactory();
    }


    [HttpGet]
    [Route("api/GetCurrentToken")]
    public string GetCurrentToken()
    {
      var AuthToken = HttpContext.Session.GetString("AuthToken");
      return AuthToken;
    }


    [HttpGet]
    [Route("api/ProvideAuthenticationToken")]
    public string ProvideAuthenticationToken()
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

      return myToken;


    }


    [HttpGet]
    [Route("api/ProvideAuthorizationToken")]
    public string ProvideAuthorizationToken()
    {
      var authorizationToken = "";
      var authToken = HttpContext.Session.GetString("AuthToken");
      if (authToken != null)
      {
        authorizationToken = _tokenFactory.GenerateAuthorizationToken(_tokenFactory.ExtractToken(authToken));
        HttpContext.Session.SetString("ApiToken", authorizationToken);
      }

      return authorizationToken;
    }


    [HttpGet]
    [Route("api/Logout")]
    public void Logout()
    {
      HttpContext.Session.Clear();
    }


    [HttpPost]
    [Route("api/TokenToDetails")]
    public CurrentUser TokenToDetails([FromBody] MyToken token)
    {
      CurrentUser currentUser = new CurrentUser();
      var jwtToken = new JwtSecurityToken(token.Token);

      var names = jwtToken.Claims.
          Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value);

      var roles = jwtToken.Claims.
          Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);

      var urls = jwtToken.Claims.
          Where(x => x.Type == ClaimTypes.Uri).Select(x => x.Value);

      var idS = jwtToken.Claims.
          Where(x => x.Type == ClaimTypes.Sid).Select(x => x.Value);

      var firstNames = jwtToken.Claims.
          Where(x => x.Type == ClaimTypes.GivenName).Select(x => x.Value);

      var surnames = jwtToken.Claims.
          Where(x => x.Type == ClaimTypes.Surname).Select(x => x.Value);

      currentUser.Name = names != null ? names.FirstOrDefault() : "";
      currentUser.FirstName = firstNames != null ? firstNames.FirstOrDefault() : "";
      currentUser.LastName = surnames != null ? surnames.FirstOrDefault() : "";
      currentUser.Roles = roles != null ? roles.ToList() : new List<string>();
      currentUser.Urls = urls != null ? urls.FirstOrDefault() : "";
      currentUser.IdS = idS != null ? idS.FirstOrDefault() : "";


      return currentUser;

    }
  }
}
