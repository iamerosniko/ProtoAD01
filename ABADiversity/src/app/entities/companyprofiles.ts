export interface CompanyProfiles {
    companyProfileID?:string;
    firmID?:string;
    firmname?:string;
    firmhead?:string;
    datecomp?:string;
    srcname?:string;
    srctitle?:string;
    srcemail?:string;
    totalfw?:number;
    totalusfw?:number;
    sizecat?:number;
    firmown?:string;
    catown?:string;
    firmcert?:string;
}

export interface Certificates{
    certificateID ?:string,
    companyProfileID?:string;
    name?:string,
    dateCert?:Date
}