namespace ABADiversityClient.Models
{
  public class FirmLeaderships
  {
    public int FirmLeadershipID { get; set; }
    public string Category { get; set; }
    public int MinorityFemale { get; set; }
    public int MinorityMale { get; set; }
    public int WhiteFemale { get; set; }
    public int WhiteMale { get; set; }
    public int LGBT { get; set; }
    public int Disabled { get; set; }

    public int CompanyProfileID { get; set; }
    public int Year { get; set; }
  }
}
