using Microsoft.EntityFrameworkCore;

namespace ABADiversityAPI.Entities
{
  public class ABAContext : DbContext
  {
    public ABAContext(DbContextOptions<ABAContext> options) : base(options)
    {
      Database.Migrate();
    }
    public DbSet<CompanyProfiles> CompanyProfiles { get; set; }
    public DbSet<FirmDemographics> FirmDemographics { get; set; }
    public DbSet<FirmInitiatives> FirmInitiatives { get; set; }
    public DbSet<FirmLeaderships> FirmLeaderships { get; set; }
    public DbSet<HighCompensatedPartners> HighCompensatedPartners { get; set; }
    public DbSet<InitiativeQuestions> InitiativeQuestions { get; set; }
    public DbSet<JoinedLawyers> JoinedLawyers { get; set; }
    public DbSet<LeftLawyers> LeftLawyers { get; set; }

    public DbSet<SetGroup> SetGroups { get; set; }
    public DbSet<SetUser> SetUsers { get; set; }
    public DbSet<SetUserAccess> SetUserAccesses { get; set; }


    //test
    public DbSet<Dummy> Dummies { get; set; }
  }
}
