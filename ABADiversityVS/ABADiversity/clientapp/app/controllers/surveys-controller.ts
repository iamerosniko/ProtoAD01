import { CompanyProfilesService,FirmDemographicsService,
    FirmInitiativesService,FirmLeadershipsService,
    HighCompensatedPartnersService,HomeGrownPartnersService,    
    HoursReducedLawyersService,InitiativeQuestionsService,
    JoinedLawyersService,LeftLawyersService,
    SizeCategoriesService
} from '../services/aba.services';

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

    async saveSurvey(surveys:Surveys,isNew:boolean):Promise<boolean>{
        var cpRes = isNew 
        ? <aba.CompanyProfiles> await this.companyProfilesService.postCompanyProfiles(surveys.CompanyProfile)
        : <aba.CompanyProfiles> await this.companyProfilesService.putCompanyProfiles(surveys.CompanyProfile);
        
        var fdRes:aba.FirmDemographics[];
        var flRes:aba.FirmLeaderships[];
        var hgpRes:aba.HomegrownPartners[];
        var llRes:aba.LeftLawyers[];
        var jlRes:aba.JoinedLawyers[];
        var hrlRes:aba.HoursReducedLawyers[];
        var hcpRes:aba.HighCompensatedPartners[];
        var fiRes:aba.FirmInitiatives[];
        var isComplete:boolean= false;
       
        surveys.FIrmDemographics.forEach(async (element) => {
            isNew 
            ?
                fdRes.push(<aba.FirmDemographics>await this.firmDemographicsService.postFirmDemographics(element))
            : 
                fdRes.push(<aba.FirmDemographics>await this.firmDemographicsService.postFirmDemographics(element))                           
            ;
        });

        surveys.FirmLeaderships.forEach(async (element) => {
            isNew
            ?
                flRes.push(<aba.FirmLeaderships>await this.firmLeadershipsService.postFirmLeaderships(element)) 
            : 
                flRes.push(<aba.FirmLeaderships>await this.firmLeadershipsService.postFirmLeaderships(element))                         
            ;
                    
        });

        surveys.HomegrownPartners.forEach(async (element) => {
            isNew 
            ? 
                hgpRes.push(<aba.HomegrownPartners>await this.homeGrownPartnersService.postHomeGrownPartners(element))
            : 
                hgpRes.push(<aba.HomegrownPartners>await this.homeGrownPartnersService.postHomeGrownPartners(element))                        
            ;
        });

        surveys.LeftLawyers.forEach(async (element) => {
            isNew 
            ? 
                llRes.push(<aba.LeftLawyers>await this.leftLawyersService.postLeftLawyers(element))
            : 
                llRes.push(<aba.LeftLawyers>await this.leftLawyersService.postLeftLawyers(element))                        
            ;
        });

        surveys.JoinedLawyers.forEach(async (element) => {
            isNew 
            ? 
                jlRes.push(<aba.JoinedLawyers>await this.joinedLawyersService.postJoinedLawyers(element))
            : 
                jlRes.push(<aba.JoinedLawyers>await this.joinedLawyersService.putJoinedLawyers(element))                        
            ;
        });

        surveys.HoursReducedLawyers.forEach(async (element) => {
            isNew 
            ?
                hrlRes.push(<aba.HoursReducedLawyers>await this.hoursReducedLawyersService.postHoursReducedLawyers(element))
            : 
                hrlRes.push(<aba.HoursReducedLawyers>await this.hoursReducedLawyersService.putHoursReducedLawyers(element))
            ;
        });

        surveys.HighCompensatedPartners.forEach(async (element) => {
            isNew 
            ? 
                hcpRes.push(<aba.HighCompensatedPartners>await this.highCompensatedPartnersService.postHighCompensatedPartners(element))
            : 
                hcpRes.push(<aba.HighCompensatedPartners>await this.highCompensatedPartnersService.putHighCompensatedPartners(element))
            ;
        });

        surveys.FirmInitiatives.forEach(async (element) => {
            isNew 
            ? 
                fiRes.push(<aba.FirmInitiatives>await this.firmInitiativesService.postFirmInitiatives(element))
            : 
                fiRes.push(<aba.FirmInitiatives>await this.firmInitiativesService.putFirmInitiatives(element))
            ;
        });

        isComplete=await true;
    
        return new Promise<boolean>((res)=>res(isComplete));
    }
}
