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

    fdRes:aba.FirmDemographics[];
    flRes:aba.FirmLeaderships[];
    hgpRes:aba.HomegrownPartners[];
    llRes:aba.LeftLawyers[];
    jlRes:aba.JoinedLawyers[];
    hrlRes:aba.HoursReducedLawyers[];
    hcpRes:aba.HighCompensatedPartners[];
    fiRes:aba.FirmInitiatives[];
    companyProfileID : string ='';

    constructor( private companyProfilesService: CompanyProfilesService, private firmDemographicsService : FirmDemographicsService,
        private firmInitiativesService:FirmInitiativesService, private firmLeadershipsService : FirmLeadershipsService,
        private highCompensatedPartnersService : HighCompensatedPartnersService, private homeGrownPartnersService : HomeGrownPartnersService,
        private hoursReducedLawyersService : HoursReducedLawyersService, private initiativeQuestionsService : InitiativeQuestionsService,
        private joinedLawyersService :JoinedLawyersService,private leftLawyersService :LeftLawyersService,
        private sizeCategoriesService : SizeCategoriesService
        ){

    }

    public async saveSurvey(surveys:Surveys,isNew:boolean):Promise<boolean>{
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


    public async getSurvey(companyProfileID:string):Promise<Surveys>{
        this.companyProfileID= await companyProfileID;
        var cpRes =<aba.CompanyProfiles> await this.companyProfilesService.getCompanyProfile(companyProfileID);
        await this.getDependencies();

        var surveys:Surveys =await {
            CompanyProfile : cpRes,
            FIrmDemographics : this.fdRes,
            FirmInitiatives : this.fiRes,
            FirmLeaderships :this.flRes,
            HighCompensatedPartners : this.hcpRes,
            HomegrownPartners : this.hgpRes,
            HoursReducedLawyers : this.hrlRes,
            JoinedLawyers : this.jlRes,
            LeftLawyers : this.llRes 
        };
        return new Promise<Surveys>((res)=>res(surveys));
    }

    private async getDependencies(){
        this.fdRes =(<aba.FirmDemographics[]> await this.firmDemographicsService.getFirmDemographics()).filter(x=>x.CompanyProfileID==this.companyProfileID); 
        this.flRes =(<aba.FirmLeaderships[]> await this.firmLeadershipsService.getFirmLeaderships()).filter(x=>x.CompanyProfileID==this.companyProfileID); 
        this.hgpRes =(<aba.HomegrownPartners[]> await this.homeGrownPartnersService.getHomeGrownPartners()).filter(x=>x.CompanyProfileID==this.companyProfileID); 
        this.llRes =(<aba.LeftLawyers[]> await this.leftLawyersService.getLeftLawyers()).filter(x=>x.CompanyProfileID==this.companyProfileID); 
        this.jlRes =(<aba.JoinedLawyers[]> await this.joinedLawyersService.getJoinedLawyers()).filter(x=>x.CompanyProfileID==this.companyProfileID); 
        this.hrlRes =(<aba.HoursReducedLawyers[]> await this.hoursReducedLawyersService.getHoursReducedLawyers()).filter(x=>x.CompanyProfileID==this.companyProfileID); 
        this.hcpRes =(<aba.HighCompensatedPartners[]> await this.highCompensatedPartnersService.getHighCompensatedPartners()).filter(x=>x.CompanyProfileID==this.companyProfileID); 
        this.fiRes =(<aba.FirmInitiatives[]> await this.firmInitiativesService.getFirmInitiatives()).filter(x=>x.CompanyProfileID==this.companyProfileID); 
    }
}
