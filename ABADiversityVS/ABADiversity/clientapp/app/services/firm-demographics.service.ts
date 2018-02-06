import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
@Injectable()
export class FirmDemographicsService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("FirmDemographics")
  }

  getCompanyProfiles(){
    return this.api.getAll();
  }
}
