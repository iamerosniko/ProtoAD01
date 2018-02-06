namespace ABADiversityClient.Models
{
  public class HomegrownPartners
  {
    public int HomegrownPartnersID { get; set; }
    public string Gender { get; set; }
    public int Minority { get; set; }
    public int White { get; set; }
    public int LGBT { get; set; }
    public int Disabled { get; set; }

    public int CompanyProfileID { get; set; }
  }
}
