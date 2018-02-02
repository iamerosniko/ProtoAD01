using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABADiversityClient.Controllers
{

  [Produces("application/json")]
  public class MyTokenController : Controller
  {
    // GET: api/MyToken
    [HttpGet]

    [Route("api/GenerateToken")]
    public MyToken GenerateToken()
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
      var authToken = HttpContext.Session.GetString("AuthToken");
      return authToken;
    }

  }
}
