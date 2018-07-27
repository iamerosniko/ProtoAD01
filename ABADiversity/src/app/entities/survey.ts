import {Certificates,CompanyProfiles,FirmDemographics,
    Firms,JoinedLawyers,LeadershipDemographics,
    LeftLawyers,PromotionsAssociatePartners,ReducedHoursLawyers,
    TopTenHighestCompensations,UndertakenInitiatives} from './entities'
    
export interface Survey{
    Firm?:Firms;
    Companyprofile?:CompanyProfiles;
    UndertakenInitiatives ?: UndertakenInitiatives;
    FirmDemographics ?: FirmDemographics[],
    JoinedLawyers ?: JoinedLawyers[],
    LeadershipDemographics ?: LeadershipDemographics[];
    LeftLawyers ?: LeftLawyers[];
    PromotionsAssociatePartners ?: PromotionsAssociatePartners[];
    ReducedhoursLawyers ?: ReducedHoursLawyers[];
    Certificates ?: Certificates[];
    TopTenHighestCompensations ?: TopTenHighestCompensations[];
    IsNewFirm?:boolean;
}