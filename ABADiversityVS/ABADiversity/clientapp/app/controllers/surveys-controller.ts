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

    async postSurvey(surveys:Surveys){
        //var cpRes = await this.companyProfilesService
    }
}
