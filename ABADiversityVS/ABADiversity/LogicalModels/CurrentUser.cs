using System.Collections.Generic;

namespace ABADiversityClient.LogicalModels
{
  public class CurrentUser
  {
    public string UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> Roles { get; set; }

    public CurrentUser()
    {
      Roles = new List<string>();
      UserID = "";
      FirstName = "";
      LastName = "";
    }
  }
}
