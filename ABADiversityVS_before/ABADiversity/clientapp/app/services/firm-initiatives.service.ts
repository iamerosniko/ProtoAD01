import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { FirmInitiatives } from '../entities/aba-entities';
@Injectable()
export class FirmInitiativesService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("FirmInitiatives")
  }
  getFirmInitiatives(){
    return this.api.getAll();
  }
  
  postFirmInitiatives(firmInitiative:FirmInitiatives){
    var body = JSON.stringify(firmInitiative);
    return this.api.postData(body);  
  }

  putFirmInitiatives(firmInitiative:FirmInitiatives){
    var body = JSON.stringify(firmInitiative);
    return this.api.putData(body,firmInitiative.FirmInitiativesID.toString());  
  }
}

