using System;

namespace API.Tables
{
  public class CompanyProfile
  {
    public Guid CompanyProfileID { get; set; }
    public string FirmName { get; set; }
    public string RespondentContactName { get; set; }
    public string RespondentContactTitle { get; set; }
    public string RespondentContactEmail { get; set; }
    public string HeadManagingPartner { get; set; }
    public DateTime DateSurveyCompletion { get; set; }
    public int TotalLawyerFirmWide { get; set; }
    public int TotalUSLawyerFirmWide { get; set; }
  }
}
