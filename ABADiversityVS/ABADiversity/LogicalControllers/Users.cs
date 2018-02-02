using ABADiversityClient.LogicalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ABADiversityClient.LogicalControllers
{
  public class Users
  {
    public CurrentUser GetCurrentUser()
    {
      CurrentUser currentUser = new CurrentUser();
      var username = Environment.UserName;
      var setUsersController = new SetUsersController();
      var setUserAccessController = new SetUserAccessesController();
      var setGroupsController = new SetGroupsController();


      //determine if the user is available 
      try
      {
        var users = setUsersController.Get().Result;
        var groups = setGroupsController.Get().Result;
        var userAccesses = setUserAccessController.Get().Result;
        var user = users.Where(x => x.user_name == username).FirstOrDefault();

        if (user != null)
        {
          currentUser.UserID = user.user_id;
          currentUser.FirstName = user.user_first_name;
          currentUser.LastName = user.user_last_name;

          var userAccess = userAccesses.Where(x => x.user_id == user.user_id).FirstOrDefault();

          if (userAccess != null)
          {
            var groupnames = groups.Where(x => x.grp_id == userAccess.grp_id).Select(x => x.grp_name);
            foreach (var groupname in groupnames)
            {
              currentUser.Roles.Add(groupname);
            }
            //currentUser.Role = group.grp_name;
          }
        }
      }
      catch
      {
        currentUser = new CurrentUser()
        {
          Roles = new List<string>()
          {
            "noaccess"
          },

        };
      }


      return currentUser;
    }

    //authentication
    public List<Claim> getCurrentClaims(CurrentUser currentUser)
    {

      List<Claim> claims = new List<Claim>();

      claims.Add(new Claim(ClaimTypes.GivenName, currentUser == null ? "" : currentUser.FirstName));
      claims.Add(new Claim(ClaimTypes.Surname, currentUser == null ? "" : currentUser.LastName));

      foreach (var role in currentUser.Roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, currentUser == null ? "" : role));
      }



      return claims;
    }
  }
}
