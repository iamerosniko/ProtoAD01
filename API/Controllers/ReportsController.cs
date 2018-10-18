using API.DTO;
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


    private IEnumerable<CompanyProfiles> companyProfiles;

    private string[] Races = new string[] { "Asian", "Multiracial","Women", "Hispanic/Latino",
        "Native Hawaiian/Other Pacific Islander", "African American/Black(not Hispanic/Latino)",
        "Disabled","Alaska Native/American Indian","White", "Men","LGBT",
      };

    private string[] DiversityRankRace = new string[] { "Asian", "Multiracial", "Hispanic/Latino",
        "Native Hawaiian/Other Pacific Islander", "African American/Black(not Hispanic/Latino)",
        "Alaska Native/American Indian","White"
      };

    private string[] Minorities = new string[] { "Asian", "Multiracial", "Hispanic/Latino",
        "Native Hawaiian/Other Pacific Islander", "African American/Black(not Hispanic/Latino)",
        "Alaska Native/American Indian"
      };

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

    #region APIs
    [HttpGet("GetDiversityRanking/")]
    public void GetDiversityRanking()
    {

    }


    [HttpGet("GetMinorities/{firmID}/{category}/{BaseSurvey}/{TopSurvey}")]
    public List<RaceRoleValues> GetMinorities([FromRoute] Guid firmID, [FromRoute]int category, [FromRoute]Guid BaseSurvey, [FromRoute] Guid TopSurvey)
    {
      var raceRoleValues = GetReportRaceVSRole(firmID, category, BaseSurvey, TopSurvey);
      List<RaceRoleValues> minorityRaceRoleValuesTemp = new List<RaceRoleValues>();
      //filtering
      double EquityPartners;
      double OtherLawyers;
      double Associates;
      double Counsel;
      double NonEquityPartners;
      string year;

      foreach (var minority in Minorities)
      {
        var raceRoleValue = raceRoleValues.Find(x => x.Race == minority);
        if (raceRoleValue != null)
        {
          minorityRaceRoleValuesTemp.Add(raceRoleValue);
        }
      }

      //remove the rating
      foreach (var rrv in minorityRaceRoleValuesTemp)
      {
        rrv.MyRoleValues = rrv.MyRoleValues.Where(x => x.Year != "Rate").ToList();
      }

      //summation of every year
      var numberOfRaceRoleValue = minorityRaceRoleValuesTemp.Count();
      if (numberOfRaceRoleValue == 0)
      {
        return new List<RaceRoleValues>();
      }

      var numberOfYears = minorityRaceRoleValuesTemp[0].MyRoleValues.Count();

      List<RaceRoleValues> minoritySummationList = new List<RaceRoleValues>();
      RaceRoleValues minorityRaceRoleValue = new RaceRoleValues
      {
        Race = "Minorities",
        MyRoleValues = new List<RoleValues>()
      };


      for (int i = 0; i < numberOfYears; i++)
      {
        EquityPartners = 0;
        OtherLawyers = 0;
        Associates = 0;
        Counsel = 0;
        NonEquityPartners = 0;
        year = "";
        for (int j = 0; j < numberOfRaceRoleValue; j++)
        {
          EquityPartners += ConvertToNumber(minorityRaceRoleValuesTemp[j].MyRoleValues[i].EquityPartners);
          OtherLawyers += ConvertToNumber(minorityRaceRoleValuesTemp[j].MyRoleValues[i].OtherLawyers);
          Associates += ConvertToNumber(minorityRaceRoleValuesTemp[j].MyRoleValues[i].Associates);
          Counsel += ConvertToNumber(minorityRaceRoleValuesTemp[j].MyRoleValues[i].Counsel);
          NonEquityPartners += ConvertToNumber(minorityRaceRoleValuesTemp[j].MyRoleValues[i].NonEquityPartners);
          year = minorityRaceRoleValuesTemp[j].MyRoleValues[i].Year;
        }

        var minorityRoleValue = new RoleValues
        {
          Associates = Associates.ToString(),
          Counsel = Counsel.ToString(),
          EquityPartners = EquityPartners.ToString(),
          NonEquityPartners = NonEquityPartners.ToString(),
          OtherLawyers = NonEquityPartners.ToString(),
          Year = year
        };

        minorityRoleValue.Total = Compute(minorityRoleValue);
        minorityRaceRoleValue.MyRoleValues.Add(minorityRoleValue);
      }
      RoleValues rateRoleValue = new RoleValues();
      rateRoleValue = getRate("Rate", minorityRaceRoleValue.MyRoleValues);
      minorityRaceRoleValue.MyRoleValues.Add(rateRoleValue);
      //main RaceVSRoles
      minoritySummationList.Add(minorityRaceRoleValue);


      return minoritySummationList;
    }

    [HttpGet("GetReportRaceVSRole/{firmID}/{category}/{BaseSurvey}/{TopSurvey}")]
    public List<RaceRoleValues> GetReportRaceVSRole([FromRoute] Guid firmID, [FromRoute]int category, [FromRoute]Guid BaseSurvey, [FromRoute] Guid TopSurvey)
    {

      var firm = _context.Firms.SingleOrDefault(x => x.FirmID == firmID);
      if (firm == null)
      {
        return null;
      }
      //get companyProfiles of this firm
      companyProfiles = companyProfilesController.GetCompanyProfiles(firm.FirmID);
      var baseCompanyProfiledate = companyProfiles.FirstOrDefault(x => x.CompanyProfileID == BaseSurvey).Datecomp;
      var topCompanyProfiledate = companyProfiles.FirstOrDefault(x => x.CompanyProfileID == TopSurvey).Datecomp;
      //remove companyprofiles of base and top
      var insideScopeOfCompanyProfiles = companyProfiles.Where(x => x.CompanyProfileID != BaseSurvey);
      insideScopeOfCompanyProfiles = insideScopeOfCompanyProfiles.Where(x => x.CompanyProfileID != TopSurvey);
      //filter betweendates
      insideScopeOfCompanyProfiles = insideScopeOfCompanyProfiles.Where(x => x.Datecomp > baseCompanyProfiledate && x.Datecomp < topCompanyProfiledate).OrderBy(x => x.Datecomp);

      if (category == 0)
      {
        return getCategoryOfAllValues(BaseSurvey, TopSurvey, insideScopeOfCompanyProfiles);
      }
      List<List<GenericDataSurveyDTO>> genericDataSurveys = getCategoryValues(category, BaseSurvey, TopSurvey, insideScopeOfCompanyProfiles);

      List<RaceRoleValues> raceRoleValues = new List<RaceRoleValues>();
      RaceRoleValues raceRoleValue = new RaceRoleValues();

      if (genericDataSurveys.Count() != 0)
      {
        foreach (var race in Races)
        {
          raceRoleValue = new RaceRoleValues();
          raceRoleValue.MyRoleValues = new List<RoleValues>();
          foreach (var glds in genericDataSurveys)
          {
            var currentRace = glds.SingleOrDefault(x => x.RegionName == race);
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
      }


      return raceRoleValues;
    }
    #endregion

    private RoleValues getRate(string race, List<RoleValues> roleValues)
    {
      double baseAssociates = ConvertToNumber(roleValues.First().Associates);
      double baseCounsel = ConvertToNumber(roleValues.First().Counsel);
      double baseEquityPartners = ConvertToNumber(roleValues.First().EquityPartners);
      double baseNonEquityPartners = ConvertToNumber(roleValues.First().NonEquityPartners);
      double baseOtherLawyers = ConvertToNumber(roleValues.First().OtherLawyers);
      double baseTotal = ConvertToNumber(roleValues.First().Total);

      double topAssociates = ConvertToNumber(roleValues.Last().Associates);
      double topCounsel = ConvertToNumber(roleValues.Last().Counsel);
      double topEquityPartners = ConvertToNumber(roleValues.Last().EquityPartners);
      double topNonEquityPartners = ConvertToNumber(roleValues.Last().NonEquityPartners);
      double topOtherLawyers = ConvertToNumber(roleValues.Last().OtherLawyers);
      double topTotal = ConvertToNumber(roleValues.Last().Total);


      double rateAssociates = Math.Round(((topAssociates - baseAssociates) / baseAssociates) * 100, 2);
      double rateCounsel = Math.Round(((topCounsel - baseCounsel) / baseCounsel) * 100, 2);
      double rateEquityPartners = Math.Round(((topEquityPartners - baseEquityPartners) / baseEquityPartners) * 100, 2);
      double rateNonEquityPartners = Math.Round(((topNonEquityPartners - baseNonEquityPartners) / baseNonEquityPartners) * 100, 2);
      double rateOtherLawyers = Math.Round(((topOtherLawyers - baseOtherLawyers) / baseOtherLawyers) * 100, 2);
      double rateTotal = Math.Round(((topTotal - baseTotal) / baseTotal) * 100, 2);

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
      roleValue.Total += "%";
      roleValue.Year = "Rate";

      return roleValue;
    }

    private string Compute(RoleValues roleValue)
    {
      return (

        ConvertToNumber(roleValue.EquityPartners) +
        ConvertToNumber(roleValue.NonEquityPartners) +
        ConvertToNumber(roleValue.OtherLawyers) +
        ConvertToNumber(roleValue.Associates) +
        ConvertToNumber(roleValue.Counsel)
        ).ToString();

    }

    private double ConvertToNumber(string stringValue)
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

    #region all
    public List<RaceRoleValues> getCategoryOfAllValues(Guid BaseSurvey, Guid TopSurvey, IEnumerable<CompanyProfiles> insideScopeOfCompanyProfiles)
    {
      var fd = getCategoryValues(2, BaseSurvey, TopSurvey, insideScopeOfCompanyProfiles);
      var pap = getCategoryValues(4, BaseSurvey, TopSurvey, insideScopeOfCompanyProfiles);
      var ll = getCategoryValues(5, BaseSurvey, TopSurvey, insideScopeOfCompanyProfiles);
      var jl = getCategoryValues(6, BaseSurvey, TopSurvey, insideScopeOfCompanyProfiles);
      var rhl = getCategoryValues(7, BaseSurvey, TopSurvey, insideScopeOfCompanyProfiles);

      var rrvFD = getRaceRoleValues(fd);
      var rrvPAP = getRaceRoleValues(pap);
      var rrvLL = getRaceRoleValues(ll);
      var rrvJL = getRaceRoleValues(jl);
      var rrvRHL = getRaceRoleValues(rhl);


      List<RaceRoleValues> allRaceRoleValues = new List<RaceRoleValues>();


      foreach (var race in Races)
      {
        var racevalueofFD = rrvFD.Find(x => x.Race == race);
        var racevalueofpap = rrvPAP.Find(x => x.Race == race);
        var racevalueofLL = rrvLL.Find(x => x.Race == race);
        var racevalueofJL = rrvJL.Find(x => x.Race == race);
        var racevalueofRHL = rrvRHL.Find(x => x.Race == race);
        List<RoleValues> rolevalues = new List<RoleValues>();
        for (int i = 0; i < racevalueofFD.MyRoleValues.Count(); i++)
        {

          var assoc = ConvertToNumber(racevalueofFD.MyRoleValues[i].Associates)
            + ConvertToNumber(racevalueofJL.MyRoleValues[i].Associates)
            + ConvertToNumber(racevalueofpap.MyRoleValues[i].Associates)
            + ConvertToNumber(racevalueofLL.MyRoleValues[i].Associates)
            + ConvertToNumber(racevalueofRHL.MyRoleValues[i].Associates);

          var counsel = ConvertToNumber(racevalueofFD.MyRoleValues[i].Counsel)
            + ConvertToNumber(racevalueofJL.MyRoleValues[i].Counsel)
            + ConvertToNumber(racevalueofpap.MyRoleValues[i].Counsel)
            + ConvertToNumber(racevalueofLL.MyRoleValues[i].Counsel)
            + ConvertToNumber(racevalueofRHL.MyRoleValues[i].Counsel);

          var ep = ConvertToNumber(racevalueofFD.MyRoleValues[i].EquityPartners)
            + ConvertToNumber(racevalueofJL.MyRoleValues[i].EquityPartners)
            + ConvertToNumber(racevalueofpap.MyRoleValues[i].EquityPartners)
            + ConvertToNumber(racevalueofLL.MyRoleValues[i].EquityPartners)
            + ConvertToNumber(racevalueofRHL.MyRoleValues[i].EquityPartners);

          var nep = ConvertToNumber(racevalueofFD.MyRoleValues[i].NonEquityPartners)
            + ConvertToNumber(racevalueofJL.MyRoleValues[i].NonEquityPartners)
            + ConvertToNumber(racevalueofpap.MyRoleValues[i].NonEquityPartners)
            + ConvertToNumber(racevalueofLL.MyRoleValues[i].NonEquityPartners)
            + ConvertToNumber(racevalueofRHL.MyRoleValues[i].NonEquityPartners);

          var ol = ConvertToNumber(racevalueofFD.MyRoleValues[i].OtherLawyers)
            + ConvertToNumber(racevalueofJL.MyRoleValues[i].OtherLawyers)
            + ConvertToNumber(racevalueofpap.MyRoleValues[i].OtherLawyers)
            + ConvertToNumber(racevalueofLL.MyRoleValues[i].OtherLawyers)
            + ConvertToNumber(racevalueofRHL.MyRoleValues[i].OtherLawyers);

          var total = ConvertToNumber(racevalueofFD.MyRoleValues[i].Total)
            + ConvertToNumber(racevalueofJL.MyRoleValues[i].Total)
            + ConvertToNumber(racevalueofpap.MyRoleValues[i].Total)
            + ConvertToNumber(racevalueofLL.MyRoleValues[i].Total)
            + ConvertToNumber(racevalueofRHL.MyRoleValues[i].Total);

          var allYear = racevalueofFD.MyRoleValues[i].Year;
          rolevalues.Add(new RoleValues
          {
            Associates = assoc.ToString(),
            Counsel = counsel.ToString(),
            EquityPartners = ep.ToString(),
            NonEquityPartners = nep.ToString(),
            OtherLawyers = ol.ToString(),
            Total = total.ToString(),
            Year = allYear
          });

        }
        //for rate
        RoleValues rateRoleValue = new RoleValues();
        rateRoleValue = getRate(race, rolevalues);
        rolevalues.Add(rateRoleValue);

        allRaceRoleValues.Add(new RaceRoleValues
        {
          Race = race,
          MyRoleValues = rolevalues
        });
      }


      return allRaceRoleValues;
    }



    public List<RaceRoleValues> getRaceRoleValues(List<List<GenericDataSurveyDTO>> genericDataSurveys)
    {
      List<RaceRoleValues> raceRoleValues = new List<RaceRoleValues>();
      RaceRoleValues raceRoleValue;
      foreach (var race in Races)
      {
        raceRoleValue = new RaceRoleValues();
        raceRoleValue.MyRoleValues = new List<RoleValues>();
        foreach (var glds in genericDataSurveys)
        {
          var currentRace = glds.SingleOrDefault(x => x.RegionName == race);
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
        //main RaceVSRoles
        raceRoleValues.Add(raceRoleValue);

      }
      return raceRoleValues;
    }

    #endregion

    #region categoryFilteringConditions
    public List<List<GenericDataSurveyDTO>> getCategoryValues(int categoryNumber, Guid BaseSurvey, Guid TopSurvey, IEnumerable<CompanyProfiles> insideScopeOfCompanyProfiles)
    {
      List<List<GenericDataSurveyDTO>> genericDataSurveys = new List<List<GenericDataSurveyDTO>>();
      List<GenericDataSurveyDTO> tempGenericSurvey = new List<GenericDataSurveyDTO>();

      switch (categoryNumber)
      {
        #region FirmDemographics
        case 2:
          var baseFD = _context.FirmDemographics.Where(x => x.CompanyProfileID == BaseSurvey).ToList();
          var topSurveyFD = _context.FirmDemographics.Where(x => x.CompanyProfileID == TopSurvey).ToList();

          foreach (var bfd in baseFD)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = bfd.Associates,
              CompanyProfileID = bfd.CompanyProfileID,
              Counsel = bfd.Counsel,
              EquityPartners = bfd.EquityPartners,
              NonEquityPartners = bfd.NonEquityPartners,
              OtherLawyers = bfd.OtherLawyers,
              RegionName = bfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);
          //clear the list
          tempGenericSurvey = new List<GenericDataSurveyDTO>();

          foreach (var insideScopeOfCompanyProfile in insideScopeOfCompanyProfiles)
          {
            var firmDemo = _context.FirmDemographics.Where(x => x.CompanyProfileID == insideScopeOfCompanyProfile.CompanyProfileID).ToList();
            if (firmDemo != null)
            {
              foreach (var fd in firmDemo)
              {
                tempGenericSurvey.Add(new GenericDataSurveyDTO
                {
                  Associates = fd.Associates,
                  CompanyProfileID = fd.CompanyProfileID,
                  Counsel = fd.Counsel,
                  EquityPartners = fd.EquityPartners,
                  NonEquityPartners = fd.NonEquityPartners,
                  OtherLawyers = fd.OtherLawyers,
                  RegionName = fd.RegionName
                });
              }
              genericDataSurveys.Add(tempGenericSurvey);
              tempGenericSurvey = new List<GenericDataSurveyDTO>();
            }
          }

          foreach (var tpfd in topSurveyFD)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = tpfd.Associates,
              CompanyProfileID = tpfd.CompanyProfileID,
              Counsel = tpfd.Counsel,
              EquityPartners = tpfd.EquityPartners,
              NonEquityPartners = tpfd.NonEquityPartners,
              OtherLawyers = tpfd.OtherLawyers,
              RegionName = tpfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);
          break;

        #endregion
        #region PAP
        case 4:
          var basepap = _context.PromotionsAssociatePartners.Where(x => x.CompanyProfileID == BaseSurvey).ToList();
          var topSurveypap = _context.PromotionsAssociatePartners.Where(x => x.CompanyProfileID == TopSurvey).ToList();

          foreach (var bfd in basepap)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = bfd.Associates,
              CompanyProfileID = bfd.CompanyProfileID,
              Counsel = bfd.Counsel,
              EquityPartners = bfd.EquityPartners,
              NonEquityPartners = bfd.NonEquityPartners,
              OtherLawyers = bfd.OtherLawyers,
              RegionName = bfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);
          //clear the list
          tempGenericSurvey = new List<GenericDataSurveyDTO>();

          foreach (var insideScopeOfCompanyProfile in insideScopeOfCompanyProfiles)
          {
            var firmDemo = _context.PromotionsAssociatePartners.Where(x => x.CompanyProfileID == insideScopeOfCompanyProfile.CompanyProfileID).ToList();
            if (firmDemo != null)
            {
              foreach (var fd in firmDemo)
              {
                tempGenericSurvey.Add(new GenericDataSurveyDTO
                {
                  Associates = fd.Associates,
                  CompanyProfileID = fd.CompanyProfileID,
                  Counsel = fd.Counsel,
                  EquityPartners = fd.EquityPartners,
                  NonEquityPartners = fd.NonEquityPartners,
                  OtherLawyers = fd.OtherLawyers,
                  RegionName = fd.RegionName
                });
              }
              genericDataSurveys.Add(tempGenericSurvey);
              tempGenericSurvey = new List<GenericDataSurveyDTO>();
            }
          }

          foreach (var tpfd in topSurveypap)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = tpfd.Associates,
              CompanyProfileID = tpfd.CompanyProfileID,
              Counsel = tpfd.Counsel,
              EquityPartners = tpfd.EquityPartners,
              NonEquityPartners = tpfd.NonEquityPartners,
              OtherLawyers = tpfd.OtherLawyers,
              RegionName = tpfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);

          break;
        #endregion
        #region LeftLawyers
        case 5:
          var basell = _context.LeftLawyers.Where(x => x.CompanyProfileID == BaseSurvey).ToList();
          var topSurveyll = _context.LeftLawyers.Where(x => x.CompanyProfileID == TopSurvey).ToList();

          foreach (var bfd in basell)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = bfd.Associates,
              CompanyProfileID = bfd.CompanyProfileID,
              Counsel = bfd.Counsel,
              EquityPartners = bfd.EquityPartners,
              NonEquityPartners = bfd.NonEquityPartners,
              OtherLawyers = bfd.OtherLawyers,
              RegionName = bfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);
          //clear the list
          tempGenericSurvey = new List<GenericDataSurveyDTO>();

          foreach (var insideScopeOfCompanyProfile in insideScopeOfCompanyProfiles)
          {
            var firmDemo = _context.LeftLawyers.Where(x => x.CompanyProfileID == insideScopeOfCompanyProfile.CompanyProfileID).ToList();
            if (firmDemo != null)
            {
              foreach (var fd in firmDemo)
              {
                tempGenericSurvey.Add(new GenericDataSurveyDTO
                {
                  Associates = fd.Associates,
                  CompanyProfileID = fd.CompanyProfileID,
                  Counsel = fd.Counsel,
                  EquityPartners = fd.EquityPartners,
                  NonEquityPartners = fd.NonEquityPartners,
                  OtherLawyers = fd.OtherLawyers,
                  RegionName = fd.RegionName
                });
              }
              genericDataSurveys.Add(tempGenericSurvey);
              tempGenericSurvey = new List<GenericDataSurveyDTO>();
            }
          }

          foreach (var tpfd in topSurveyll)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = tpfd.Associates,
              CompanyProfileID = tpfd.CompanyProfileID,
              Counsel = tpfd.Counsel,
              EquityPartners = tpfd.EquityPartners,
              NonEquityPartners = tpfd.NonEquityPartners,
              OtherLawyers = tpfd.OtherLawyers,
              RegionName = tpfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);

          break;
        #endregion
        #region JoinedLawyers
        case 6:
          var basejl = _context.JoinedLawyers.Where(x => x.CompanyProfileID == BaseSurvey).ToList();
          var topSurveyjl = _context.JoinedLawyers.Where(x => x.CompanyProfileID == TopSurvey).ToList();

          foreach (var bfd in basejl)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = bfd.Associates,
              CompanyProfileID = bfd.CompanyProfileID,
              Counsel = bfd.Counsel,
              EquityPartners = bfd.EquityPartners,
              NonEquityPartners = bfd.NonEquityPartners,
              OtherLawyers = bfd.OtherLawyers,
              RegionName = bfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);
          //clear the list
          tempGenericSurvey = new List<GenericDataSurveyDTO>();

          foreach (var insideScopeOfCompanyProfile in insideScopeOfCompanyProfiles)
          {
            var firmDemo = _context.JoinedLawyers.Where(x => x.CompanyProfileID == insideScopeOfCompanyProfile.CompanyProfileID).ToList();
            if (firmDemo != null)
            {
              foreach (var fd in firmDemo)
              {
                tempGenericSurvey.Add(new GenericDataSurveyDTO
                {
                  Associates = fd.Associates,
                  CompanyProfileID = fd.CompanyProfileID,
                  Counsel = fd.Counsel,
                  EquityPartners = fd.EquityPartners,
                  NonEquityPartners = fd.NonEquityPartners,
                  OtherLawyers = fd.OtherLawyers,
                  RegionName = fd.RegionName
                });
              }
              genericDataSurveys.Add(tempGenericSurvey);
              tempGenericSurvey = new List<GenericDataSurveyDTO>();
            }
          }

          foreach (var tpfd in topSurveyjl)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = tpfd.Associates,
              CompanyProfileID = tpfd.CompanyProfileID,
              Counsel = tpfd.Counsel,
              EquityPartners = tpfd.EquityPartners,
              NonEquityPartners = tpfd.NonEquityPartners,
              OtherLawyers = tpfd.OtherLawyers,
              RegionName = tpfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);

          break;

        #endregion
        #region RHL
        case 7:
          var baserhl = _context.ReducedHoursLawyers.Where(x => x.CompanyProfileID == BaseSurvey).ToList();
          var topSurveyrhl = _context.ReducedHoursLawyers.Where(x => x.CompanyProfileID == TopSurvey).ToList();

          foreach (var bfd in baserhl)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = bfd.Associates,
              CompanyProfileID = bfd.CompanyProfileID,
              Counsel = bfd.Counsel,
              EquityPartners = bfd.EquityPartners,
              NonEquityPartners = bfd.NonEquityPartners,
              OtherLawyers = bfd.OtherLawyers,
              RegionName = bfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);
          //clear the list
          tempGenericSurvey = new List<GenericDataSurveyDTO>();

          foreach (var insideScopeOfCompanyProfile in insideScopeOfCompanyProfiles)
          {
            var firmDemo = _context.ReducedHoursLawyers.Where(x => x.CompanyProfileID == insideScopeOfCompanyProfile.CompanyProfileID).ToList();
            if (firmDemo != null)
            {
              foreach (var fd in firmDemo)
              {
                tempGenericSurvey.Add(new GenericDataSurveyDTO
                {
                  Associates = fd.Associates,
                  CompanyProfileID = fd.CompanyProfileID,
                  Counsel = fd.Counsel,
                  EquityPartners = fd.EquityPartners,
                  NonEquityPartners = fd.NonEquityPartners,
                  OtherLawyers = fd.OtherLawyers,
                  RegionName = fd.RegionName
                });
              }
              genericDataSurveys.Add(tempGenericSurvey);
              tempGenericSurvey = new List<GenericDataSurveyDTO>();
            }
          }

          foreach (var tpfd in topSurveyrhl)
          {
            tempGenericSurvey.Add(new GenericDataSurveyDTO
            {
              Associates = tpfd.Associates,
              CompanyProfileID = tpfd.CompanyProfileID,
              Counsel = tpfd.Counsel,
              EquityPartners = tpfd.EquityPartners,
              NonEquityPartners = tpfd.NonEquityPartners,
              OtherLawyers = tpfd.OtherLawyers,
              RegionName = tpfd.RegionName
            });
          }
          genericDataSurveys.Add(tempGenericSurvey);

          break;
          #endregion
      }
      return genericDataSurveys;
    }
    #endregion


  }
}
