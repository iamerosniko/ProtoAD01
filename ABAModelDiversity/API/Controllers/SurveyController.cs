using API.DTO;
using API.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
  [Produces("application/json")]
  [Route("api/Survey")]
  public class SurveyController : Controller
  {
    private readonly ADContext _context;
    CertificatesController certificatesController;
    CompanyProfilesController companyProfilesController;
    FirmsController firmsController;
    FirmDemographicsController firmDemographicsController;
    JoinedLawyersController joinedLawyersController;
    LeftLawyersController leftLawyersController;
    LeadershipDemographicsController leadershipDemographicsController;
    PromotionsAssociatePartnersController promotionsAssociatePartnersController;
    ReducedHoursLawyersController reducedHoursLawyersController;
    TopTenHighestCompensationsController topTenHighestCompensationsController;
    UndertakenInitiativesController undertakenInitiativesController;

    public SurveyController(ADContext context)
    {
      _context = context;
      certificatesController = new CertificatesController(context);
      companyProfilesController = new CompanyProfilesController(context);
      firmsController = new FirmsController(context);
      firmDemographicsController = new FirmDemographicsController(context);
      joinedLawyersController = new JoinedLawyersController(context);
      leftLawyersController = new LeftLawyersController(context);
      leadershipDemographicsController = new LeadershipDemographicsController(context);
      promotionsAssociatePartnersController = new PromotionsAssociatePartnersController(context);
      reducedHoursLawyersController = new ReducedHoursLawyersController(context);
      topTenHighestCompensationsController = new TopTenHighestCompensationsController(context);
      undertakenInitiativesController = new UndertakenInitiativesController(context);
    }

    [HttpPost]
    public async Task<IActionResult> SaveSUrvey(Survey survey)
    {
      if (survey.IsNewFIrm)
      {
        var firm = await firmsController.PostFirms(survey.Firm);
      }

      var fd = await firmDemographicsController.PostFirmDemographics(survey.FirmDemographics, survey.CompanyProfile.CompanyProfileID);
      var jl = await joinedLawyersController.PostJoinedLawyers(survey.JoinedLawyers, survey.CompanyProfile.CompanyProfileID);
      var ll = await leftLawyersController.PostLeftLawyers(survey.LeftLawyers, survey.CompanyProfile.CompanyProfileID);
      var pap = await promotionsAssociatePartnersController.PostPromotionsAssociatePartners(survey.PromotionsAssociatePartners, survey.CompanyProfile.CompanyProfileID);
      var rhl = await reducedHoursLawyersController.PostReducedHoursLawyers(survey.ReducedHoursLawyers, survey.CompanyProfile.CompanyProfileID);
      var thc = await topTenHighestCompensationsController.PostTopTenHighestCompensations(survey.TopTenHighestCompensations, survey.CompanyProfile.CompanyProfileID);
      var cert = await certificatesController.PostCertificates(survey.Certificates, survey.CompanyProfile.CompanyProfileID);
      var ld = await leadershipDemographicsController.PostLeadershipDemographics(survey.LeadershipDemographics, survey.CompanyProfile.CompanyProfileID);

      var cp = await companyProfilesController.PostCompanyProfiles(survey.CompanyProfile);
      var ui = await undertakenInitiativesController.PostUndertakenInitiatives(survey.UndertakenInitiatives);

      return Ok();
    }
  }
}
