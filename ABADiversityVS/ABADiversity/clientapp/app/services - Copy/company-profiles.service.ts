import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
@Injectable()
export class CompanyProfilesService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("CompanyProfiles")
  }

  getCompanyProfiles(){
    return this.api.getAll();
  }

}
