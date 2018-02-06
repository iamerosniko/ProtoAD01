using ABADiversityClient.LogicalControllers;
using ABADiversityClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ABADiversityClient.Controllers
{
  [Produces("application/json")]
  [Route("api/Surveys")]
  public class SurveysController : Controller
  {
    private ApiAccess _webApiAccess;
    // GET: api/Surveys
    //[HttpGet]
    //public async Task<SurveyForms[]> Get()
    //{
    //  _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
    //  var result = await _webApiAccess.GetRequest();
    //  return JsonConvert.DeserializeObject<SurveyForms[]>(result.ToString());
    //}

    //// GET: api/Surveys/5
    //[HttpGet("{id}")]
    //public async Task<SurveyForms> Get(int id)
    //{
    //  _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
    //  var result = await _webApiAccess.GetRequest(id.ToString());
    //  return JsonConvert.DeserializeObject<SurveyForms>(result.ToString());
    //}

    // POST: api/Surveys
    [HttpPost]
    public async Task<SurveyForms> Post([FromBody]SurveyForms body)
    {
      CompanyProfilesController companyProfilesController = new CompanyProfilesController();

      FirmDemographicsController firmDemographicsController = new FirmDemographicsController();
      FirmInitiativesController firmInitiativesController = new FirmInitiativesController();
      FirmLeadershipsController firmLeadershipsController = new FirmLeadershipsController();
      HighCompensatedPartnersController highCompensatedPartnersController = new HighCompensatedPartnersController();
      HoursReducedLawyersController hoursReducedLawyersController = new HoursReducedLawyersController();
      InitiativeQuestionsController initiativeQuestionsController = new InitiativeQuestionsController();
      JoinedLawyersController joinedLawyersController = new JoinedLawyersController();
      LeftLawyersController leftLawyersController = new LeftLawyersController();
      //post company ProfileResult so we can get the primarykey of it
      var companyProfileResult = await companyProfilesController.Post(body.companyProfile);

      //use the result to link all companyProfileID to every relational tables
      body.firmDemographic.CompanyProfileID = companyProfileResult.CompanyProfileID;
      body.firmInitiatives.CompanyProfileID = companyProfileResult.CompanyProfileID;
      body.firmLeaderships.CompanyProfileID = companyProfileResult.CompanyProfileID;
      body.highCompensatedPartners.CompanyProfileID = companyProfileResult.CompanyProfileID;
      body.hoursReducedLawyers.CompanyProfileID = companyProfileResult.CompanyProfileID;
      body.leftLawyers.CompanyProfileID = companyProfileResult.CompanyProfileID;
      body.joinedLawyers.CompanyProfileID = companyProfileResult.CompanyProfileID;

      var firmDemographicResult = await firmDemographicsController.Post(body.firmDemographic);
      var firmInitiativesResult = await firmInitiativesController.Post(body.firmInitiatives);
      var firmLeadershipsResult = await firmLeadershipsController.Post(body.firmLeaderships);
      var highCompensatedPartnerResult = await highCompensatedPartnersController.Post(body.highCompensatedPartners);
      var hoursReducedLawyerResult = await hoursReducedLawyersController.Post(body.hoursReducedLawyers);
      //var initiativeQuestionResult = await initiativeQuestionsController.Post(body.initiativeQuestions);
      var leftLawyerResult = await leftLawyersController.Post(body.leftLawyers);
      var joinedLawyerResult = await joinedLawyersController.Post(body.joinedLawyers);

      if (companyProfileResult != null && firmDemographicResult != null &&
        firmInitiativesResult != null && firmLeadershipsResult != null &&
        highCompensatedPartnerResult != null && hoursReducedLawyerResult != null &&
        leftLawyerResult != null && joinedLawyerResult != null)
      {
        return JsonConvert.DeserializeObject<SurveyForms>(body.ToString());
      }

      return JsonConvert.DeserializeObject<SurveyForms>(new SurveyForms().ToString());
    }

    // PUT: api/Surveys/5
    //[HttpPut("{id}")]
    //public async Task<SurveyForms> Put(int id, [FromBody]string body)
    //{
    //  _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
    //  var content = JsonConvert.SerializeObject(body);

    //  var result = await _webApiAccess.PutRequest(id.ToString(), content);
    //  return JsonConvert.DeserializeObject<SurveyForms>(result.ToString());
    //}

    //// DELETE: api/ApiWithActions/5
    //[HttpDelete("{id}")]
    //public async Task<bool> Delete(int id)
    //{
    //  _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));

    //  var result = await _webApiAccess.DeleteRequest(id.ToString());
    //  return result;
    //}
  }
}
