export interface CPEntities {
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
certificate?:Certificates[];
// firmcertdet?:{};

}

export interface Certificates{
    id?:string,
    name?:string,
    dateCert?:Date
}