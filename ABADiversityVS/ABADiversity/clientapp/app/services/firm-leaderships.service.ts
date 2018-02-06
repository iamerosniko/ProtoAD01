import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
@Injectable()
export class FirmLeadershipsService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("FirmLeaderships")
  }

  getCompanyProfiles(){
    return this.api.getAll();
  }
}
