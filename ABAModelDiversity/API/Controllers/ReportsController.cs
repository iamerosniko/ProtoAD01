using API.DTO;
using API.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    [HttpGet("GetReportRaceVSRole/{firmID}/{category}/{BaseSurvey}/{TopSurvey}")]
    public async Task<dynamic> GetReportRaceVSRole([FromRoute] Guid firmID, [FromRoute]int category, [FromRoute]Guid BaseSurvey, [FromRoute] Guid TopSurvey)
    {
      string[] Races = new string[] { "Asian", "Multiracial","Women", "Hispanic/Latino",
        "Native Hawaiian/Other Pacific Islander", "African American/Black(not Hispanic/Latino)",
        "Disabled","Alaska Native/American Indian","White", "Men","LGBT",
      };

      var firm = _context.Firms.SingleOrDefault(x => x.FirmID == firmID);
      if (firm == null)
      {
        return null;
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
      var baseSurveyValue = _context.FirmDemographics.Where(x => x.CompanyProfileID == BaseSurvey).ToList();
      var topSurveyValue = _context.FirmDemographics.Where(x => x.CompanyProfileID == TopSurvey).ToList();

      List<List<FirmDemographics>> firmDemographics = new List<List<FirmDemographics>>();

      firmDemographics.Add(baseSurveyValue);

      foreach (var insideScopeOfCompanyProfile in insideScopeOfCompanyProfiles)
      {
        var firmDemo = _context.FirmDemographics.Where(x => x.CompanyProfileID == insideScopeOfCompanyProfile.CompanyProfileID).ToList();
        if (firmDemo != null)
        {
          firmDemographics.Add(firmDemo);
        }
      }

      firmDemographics.Add(topSurveyValue);
      List<RaceRoleValues> raceRoleValues = new List<RaceRoleValues>();
      RaceRoleValues raceRoleValue = new RaceRoleValues();


      foreach (var race in Races)
      {
        raceRoleValue = new RaceRoleValues();
        raceRoleValue.MyRoleValues = new List<RoleValues>();
        foreach (var fd in firmDemographics)
        {
          var currentRace = fd.SingleOrDefault(x => x.RegionName == race);
          if (currentRace != null)
          {
            RoleValues roleValue = new RoleValues
            {
              Associates = currentRace.Associates,
              Counsel = currentRace.Counsel,
              EquityPartners = currentRace.EquityPartners,
              NonEquityPartners = currentRace.NonEquityPartners,
              OtherLawyers = currentRace.OtherLawyers,
              Year = companyProfiles.SingleOrDefault(x => x.CompanyProfileID == currentRace.CompanyProfileID).Datecomp.Year.ToString()
            };

            roleValue.Total = Compute(roleValue);
            raceRoleValue.MyRoleValues.Add(roleValue);
          }
        }
        raceRoleValue.Race = race;
        //for rate
        RoleValues rateRoleValue = new RoleValues();
        rateRoleValue = getRate(race, raceRoleValue.MyRoleValues);
        raceRoleValue.MyRoleValues.Add(rateRoleValue);
        //main RaceVSRoles
        raceRoleValues.Add(raceRoleValue);


      }

      return raceRoleValues;
    }

    private RoleValues getRate(string race, List<RoleValues> roleValues)
    {
      double baseAssociates = ConvertToInt(roleValues.First().Associates);
      double baseCounsel = ConvertToInt(roleValues.First().Counsel);
      double baseEquityPartners = ConvertToInt(roleValues.First().EquityPartners);
      double baseNonEquityPartners = ConvertToInt(roleValues.First().NonEquityPartners);
      double baseOtherLawyers = ConvertToInt(roleValues.First().OtherLawyers);
      double baseTotal = ConvertToInt(roleValues.First().Total);

      double topAssociates = ConvertToInt(roleValues.Last().Associates);
      double topCounsel = ConvertToInt(roleValues.Last().Counsel);
      double topEquityPartners = ConvertToInt(roleValues.Last().EquityPartners);
      double topNonEquityPartners = ConvertToInt(roleValues.Last().NonEquityPartners);
      double topOtherLawyers = ConvertToInt(roleValues.Last().OtherLawyers);
      double topTotal = ConvertToInt(roleValues.Last().Total);


      double rateAssociates = ((topAssociates - baseAssociates) / baseAssociates) * 100;
      double rateCounsel = ((topCounsel - baseCounsel) / baseCounsel) * 100;
      double rateEquityPartners = ((topEquityPartners - baseEquityPartners) / baseEquityPartners) * 100;
      double rateNonEquityPartners = ((topNonEquityPartners - baseNonEquityPartners) / baseNonEquityPartners) * 100;
      double rateOtherLawyers = ((topOtherLawyers - baseOtherLawyers) / baseOtherLawyers) * 100;
      double rateTotal = ((topTotal - baseTotal) / baseTotal) * 100;

      RoleValues roleValue = new RoleValues
      {
        Associates = rateAssociates.ToString(),
        Counsel = rateCounsel.ToString(),
        EquityPartners = rateEquityPartners.ToString(),
        NonEquityPartners = rateNonEquityPartners.ToString(),
        OtherLawyers = rateOtherLawyers.ToString(),
        Total = rateTotal.ToString()
      };
      //roleValue.Total = Compute(roleValue);
      roleValue.Associates += "%";
      roleValue.Counsel += "%";
      roleValue.EquityPartners += "%";
      roleValue.NonEquityPartners += "%";
      roleValue.OtherLawyers += "%";
      roleValue.Year = "Rate";

      return roleValue;
    }

    private string Compute(RoleValues roleValue)
    {
      return (

        ConvertToInt(roleValue.EquityPartners) +
        ConvertToInt(roleValue.NonEquityPartners) +
        ConvertToInt(roleValue.OtherLawyers) +
        ConvertToInt(roleValue.Associates) +
        ConvertToInt(roleValue.Counsel)
        ).ToString();

    }

    private double ConvertToInt(string stringValue)
    {
      try
      {
        return Convert.ToDouble(stringValue);
      }
      catch
      {
        return 0;
      }
    }
  }
}
