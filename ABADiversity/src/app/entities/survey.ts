import {Certificates,CompanyProfiles,FirmDemographics,
    Firms,JoinedLawyers,LeadershipDemographics,
    LeftLawyers,PromotionsAssociatePartners,ReducedHoursLawyers,
    TopTenHighestCompensations,UndertakenInitiatives} from './entities'
    
export interface Survey{
    firm:Firms;
    companyprofiles:CompanyProfiles;
    undertakenInitiatives : UndertakenInitiatives;

    firmDemographics : FirmDemographics[],
    joinedLawyers : JoinedLawyers[],
    leadershipDemographics : LeadershipDemographics[];
    leftLawyers : LeftLawyers[];
    promotionsAssociatePartners : PromotionsAssociatePartners[];
    reducedhoursLawyers : ReducedHoursLawyers[];
    certificates : Certificates[];
    topTenHighestCompensations : TopTenHighestCompensations[];
}