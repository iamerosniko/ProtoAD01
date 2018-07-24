import * as aba from './aba-entities';

export interface Surveys {
    CompanyProfile : aba.CompanyProfiles,
    FIrmDemographics : aba.FirmDemographics[],
    FirmLeaderships : aba.FirmLeaderships[],
    HomegrownPartners : aba.HomegrownPartners[],
    LeftLawyers:aba.LeftLawyers[],
    JoinedLawyers:aba.JoinedLawyers[],
    HoursReducedLawyers : aba.HoursReducedLawyers[],
    HighCompensatedPartners:aba.HighCompensatedPartners[],
    FirmInitiatives:aba.FirmInitiatives[]  
}
