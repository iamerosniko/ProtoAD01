
import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 

@Injectable()
export class ReportService {

  constructor(private api:ClientApiService) {
    //uncomment api.authorizedHeader() if AD Authentication is enabled.
    //use api.normalHeader() if anonymous authentication is enabled.
    //api.authorizedHeader();
  }

  //use RoleVSRoles entity and RolesValues
  getRaceVsRoles(firmID : string, category:number, BaseSurvey:string, TopSurvey:string)
  {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("Reports/GetReportRaceVSRole/") +  firmID + "/" + category + "/" + BaseSurvey + "/" +TopSurvey
    return this.api.getAll();
  }
}
