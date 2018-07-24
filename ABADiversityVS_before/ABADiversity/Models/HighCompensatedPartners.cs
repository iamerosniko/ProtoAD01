using System;

namespace ABADiversityClient.Models
{
  public class HighCompensatedPartners
  {
    public int HighCompensatedPartnerID { get; set; }
    public string Race { get; set; }
    public int Men { get; set; }
    public int Women { get; set; }
    public Guid CompanyProfileID { get; set; }
  }
}
