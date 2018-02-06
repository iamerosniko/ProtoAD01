import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { FirmLeaderships } from '../entities/aba-entities';
@Injectable()
export class FirmLeadershipsService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("FirmLeaderships")
  }

  getFirmLeaderships(){
    return this.api.getAll();
  }

  postFirmLeaderships(firmLeadership:FirmLeaderships){
    var body = JSON.stringify(firmLeadership);
    return this.api.postData(body);  
  }
}
