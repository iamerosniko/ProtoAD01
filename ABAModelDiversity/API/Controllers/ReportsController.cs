using API.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
  [Produces("application/json")]
  [Route("api/Reports")]
  public class ReportsController : Controller
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

    public ReportsController(ADContext context)
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

    [HttpGet]
    public async void GetReportRaceVSRole([FromRoute] Guid firmID, [FromRoute]int category, [FromRoute]Guid BaseSurvey, [FromRoute] Guid TopSurvey)
    {
      var firm = _context.Firms.SingleOrDefault(x => x.FirmID == firmID);
      if (firm == null)
      {
        //return null;
      }
      //get companyProfiles of this firm
      var companyProfiles = companyProfilesController.GetCompanyProfiles(firm.FirmID);
      var baseCompanyProfiledate = companyProfiles.FirstOrDefault(x => x.CompanyProfileID == BaseSurvey).Datecomp;
      var topCompanyProfiledate = companyProfiles.FirstOrDefault(x => x.CompanyProfileID == TopSurvey).Datecomp;
      //remove companyprofiles of base and top
      var insideScopeOfCompanyProfiles = companyProfiles.Where(x => x.CompanyProfileID != BaseSurvey);
      insideScopeOfCompanyProfiles = insideScopeOfCompanyProfiles.Where(x => x.CompanyProfileID != TopSurvey);
      //filter betweendates
      insideScopeOfCompanyProfiles = insideScopeOfCompanyProfiles.Where(x => x.Datecomp > baseCompanyProfiledate && x.Datecomp < topCompanyProfiledate).OrderBy(x => x.Datecomp);
      //get firmdemographics
      var baseSurveyValue = _context.FirmDemographics.SingleOrDefault(x => x.CompanyProfileID == BaseSurvey);
      var topSurveyValue = _context.FirmDemographics.SingleOrDefault(x => x.CompanyProfileID == TopSurvey);

      List<FirmDemographics> firmDemographics = new List<FirmDemographics>();

      firmDemographics.Append(baseSurveyValue);

      foreach (var insideScopeOfCompanyProfile in insideScopeOfCompanyProfiles)
      {
        var firmDemo = _context.FirmDemographics.SingleOrDefault(x => x.CompanyProfileID == insideScopeOfCompanyProfile.CompanyProfileID);
        if (firmDemo != null)
        {
          firmDemographics.Append(firmDemo);
        }
      }

      firmDemographics.Append(topSurveyValue);



    }
  }
}
