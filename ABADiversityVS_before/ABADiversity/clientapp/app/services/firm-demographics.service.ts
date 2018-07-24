import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { FirmDemographics } from '../entities/aba-entities';
@Injectable()
export class FirmDemographicsService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("FirmDemographics")
  }

  getFirmDemographics(){
    return this.api.getAll();
  }
  
  postFirmDemographics(firmDemographic : FirmDemographics){
    var body = JSON.stringify(firmDemographic);
    return this.api.postData(body);  
  }

  putFirmDemographics(firmDemographic : FirmDemographics){
    var body = JSON.stringify(firmDemographic);
    return this.api.putData(body,firmDemographic.FirmDemographicsID.toString());  
  }
}
