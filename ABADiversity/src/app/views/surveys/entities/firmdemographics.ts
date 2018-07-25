
export interface FDInfo {
    firmId?:string;
    regions?:FDdetails[];
}
export interface FDdetails {
    regionName?:string;
    equityPartners?:string;
    nonEquityPartners?:string;
    associates?:string;
    counsel?:string;
    otherLawyers?:string;
}