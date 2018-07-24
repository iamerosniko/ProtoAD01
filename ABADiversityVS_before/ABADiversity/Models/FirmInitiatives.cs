using System;

namespace ABADiversityClient.Models
{
  public class FirmInitiatives
  {
    public int FirmInitiativeID { get; set; }
    //foreignkey
    public int InitiativeQuestionID { get; set; }
    public bool IfYes { get; set; }
    public string Comments { get; set; }
    public Guid CompanyProfileID { get; set; }
  }
}
