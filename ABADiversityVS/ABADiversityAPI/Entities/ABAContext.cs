using Microsoft.EntityFrameworkCore;

namespace ABADiversityAPI.Entities
{
  public class ABAContext : DbContext
  {
    DbSet<CompanyProfiles> CompanyProfiles { get; set; }
    DbSet<FirmDemographics> FirmDemographics { get; set; }
    DbSet<FirmInitiatives> FirmInitiatives { get; set; }
    DbSet<FirmLeaderships> FirmLeaderships { get; set; }
    DbSet<HighCompensatedPartners> HighCompensatedPartners { get; set; }
    DbSet<InitiativeQuestions> InitiativeQuestions { get; set; }
    DbSet<JoinedLawyers> JoinedLawyers { get; set; }
    DbSet<LeftLawyers> LeftLawyers { get; set; }


  }
}
