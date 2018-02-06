namespace ABADiversityClient.Models
{
  public class JoinedLawyers
  {
    public int JoinedLawyerID { get; set; }
    public string Races { get; set; }
    public int EquityPartners { get; set; }
    public int NonEquityPartners { get; set; }
    public int Associates { get; set; }
    public int Counsels { get; set; }
    public int OtherLawyers { get; set; }
    public int CompanyProfileID { get; set; }
  }
}