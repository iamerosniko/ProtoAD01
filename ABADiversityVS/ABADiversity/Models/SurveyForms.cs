using ABADiversityClient.Entities;

namespace ABADiversityClient.Models
{
  public class SurveyForms
  {
    public CompanyProfiles companyProfile { get; set; }
    public FirmDemographics firmDemographic { get; set; }
    public FirmInitiatives firmInitiatives { get; set; }
    public FirmLeaderships firmLeaderships { get; set; }
    public HighCompensatedPartners highCompensatedPartners { get; set; }
    public HoursReducedLawyers hoursReducedLawyers { get; set; }
    //public InitiativeQuestions initiativeQuestions { get; set; }
    public JoinedLawyers joinedLawyers { get; set; }
    public LeftLawyers leftLawyers { get; set; }
  }
}
