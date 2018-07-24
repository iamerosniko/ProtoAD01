using System;

namespace ABADiversityClient.Models
{
  public class HoursReducedLawyers
  {
    public int HoursReducedLawyerID { get; set; }
    public string Gender { get; set; }
    public int EquityPartners { get; set; }
    public int NonEquityPartners { get; set; }
    public int Associates { get; set; }
    public int Counsels { get; set; }
    public int OtherLawyers { get; set; }
    public Guid CompanyProfileID { get; set; }

  }
}
