using System;

namespace ABADiversityClient.Models
{
  public class CompanyProfiles
  {
    public int CompanyProfileID { get; set; }
    public string FirmName { get; set; }
    public string FirmHead { get; set; }
    public DateTime CompletionDate { get; set; }
    public string SurveyContactPerson { get; set; }
    public string SurveyContactTitle { get; set; }
    public string SurveyContactEmail { get; set; }
    public int TotalLawyers { get; set; }
    public int TotalUSLawyers { get; set; }
    //foreign key
    public int SizeCategoryID { get; set; }
    public bool IsFirmWomenOwned { get; set; }
    public string OwnershipCategory { get; set; }
    public bool IsFirmCertified { get; set; }
    public string CertifyingEntityName { get; set; }
    public int Year { get; set; }
  }
}
