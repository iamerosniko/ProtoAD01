namespace ABADiversityClient.Models
{
  public class FirmDemographics
  {
    public int FIrmDemographicsID { get; set; }
    public string Race { get; set; }
    public int EquityPartners { get; set; }
    public int NonEquityPartners { get; set; }
    public int Associates { get; set; }
    public int Counsels { get; set; }
    public int OtherLawyers { get; set; }

    public int CompanyProfileID { get; set; }
  }

}
