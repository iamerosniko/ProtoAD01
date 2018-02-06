import { CompanyProfilesService,FirmDemographicsService,
    FirmInitiativesService,FirmLeadershipsService,
    HighCompensatedPartnersService,HomeGrownPartnersService,    
    HoursReducedLawyersService,InitiativeQuestionsService,
    JoinedLawyersService,LeftLawyersService,
    SizeCategoriesService
} from '../services/aba.services';

// import { CompanyProfiles,FirmDemographics,FirmInitiatives,
//     FirmLeaderships,HighCompensatedPartners,HomegrownPartners,
//     HoursReducedLawyers,InitiativeQuestions,JoinedLawyers,
//     LeftLawyers,SizeCategories } from '../entities/aba-entities';

import * as aba from '../entities/aba-entities';
import { Surveys } from '../entities/surveys';
export class SurveysController {

    constructor( private companyProfilesService: CompanyProfilesService, private firmDemographicsService : FirmDemographicsService,
        private firmInitiativesService:FirmInitiativesService, private firmLeadershipsService : FirmLeadershipsService,
        private highCompensatedPartnersService : HighCompensatedPartnersService, private homeGrownPartnersService : HomeGrownPartnersService,
        private hoursReducedLawyersService : HoursReducedLawyersService, private initiativeQuestionsService : InitiativeQuestionsService,
        private joinedLawyersService :JoinedLawyersService,private leftLawyersService :LeftLawyersService,
        private sizeCategoriesService : SizeCategoriesService
        ){

    }

    async postSurvey(surveys:Surveys):Promise<boolean>{
        var cpRes =<aba.CompanyProfiles> await this.companyProfilesService.postCompanyProfiles(surveys.CompanyProfile);
        var fdRes:aba.FirmDemographics[];
        var flRes:aba.FirmLeaderships[];
        var hgpRes:aba.HomegrownPartners[];
        var llRes:aba.LeftLawyers[];
        var jlRes:aba.JoinedLawyers[];
        var hrlRes:aba.HoursReducedLawyers[];
        var hcpRes:aba.HighCompensatedPartners[];
        var fiRes:aba.FirmInitiatives[];
        var isComplete:boolean= false;
        if(cpRes.CompanyProfileID>0){
            surveys.FIrmDemographics.forEach(async (element) => {
                element.CompanyProfileID=await cpRes.CompanyProfileID
                fdRes.push(<aba.FirmDemographics>await this.firmDemographicsService.postFirmDemographics(element))       
            });

            surveys.FirmLeaderships.forEach(async (element) => {
                element.CompanyProfileID=await cpRes.CompanyProfileID
                flRes.push(<aba.FirmLeaderships>await this.firmLeadershipsService.postFirmLeaderships(element))       
            });

            surveys.HomegrownPartners.forEach(async (element) => {
                element.CompanyProfileID=await cpRes.CompanyProfileID
                hgpRes.push(<aba.HomegrownPartners>await this.homeGrownPartnersService.postHomeGrownPartners(element))       
            });

            surveys.LeftLawyers.forEach(async (element) => {
                element.CompanyProfileID=await cpRes.CompanyProfileID
                llRes.push(<aba.LeftLawyers>await this.leftLawyersService.postLeftLawyers(element))       
            });

            surveys.JoinedLawyers.forEach(async (element) => {
                element.CompanyProfileID=await cpRes.CompanyProfileID
                jlRes.push(<aba.JoinedLawyers>await this.joinedLawyersService.postJoinedLawyers(element))       
            });

            surveys.HoursReducedLawyers.forEach(async (element) => {
                element.CompanyProfileID=await cpRes.CompanyProfileID
                hrlRes.push(<aba.HoursReducedLawyers>await this.hoursReducedLawyersService.postHoursReducedLawyers(element))       
            });

            surveys.HighCompensatedPartners.forEach(async (element) => {
                element.CompanyProfileID=await cpRes.CompanyProfileID
                hcpRes.push(<aba.HighCompensatedPartners>await this.highCompensatedPartnersService.postHighCompensatedPartners(element))       
            });

            surveys.FirmInitiatives.forEach(async (element) => {
                element.CompanyProfileID=await cpRes.CompanyProfileID
                fiRes.push(<aba.FirmInitiatives>await this.firmInitiativesService.postFirmInitiatives(element))       
            });

            isComplete=true;
        }

        return new Promise<boolean>((res)=>res(isComplete));
    }
}
