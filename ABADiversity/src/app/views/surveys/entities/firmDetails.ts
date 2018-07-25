export interface firmInfo {
    firmId?:string;
    regions?:firmDetails[];
}
export interface firmDetails {
    regionName?:string;
    equityPartners?:string;
    nonEquityPartners?:string;
    associates?:string;
    counsel?:string;
    otherLawyers?:string;
}
export interface firmDetailsLead {
    regionName?:string;
    minorityFemale?:string;
    minorityMale?:string;
    whiteFemale?:string;
    whiteMale?:string;
    lgbt?:string;
    disabled?:string;
}