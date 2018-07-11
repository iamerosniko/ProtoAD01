import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { HighCompensatedPartners } from '../entities/aba-entities';
@Injectable()
export class HighCompensatedPartnersService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("HighCompensatedPartners")
  }

  getHighCompensatedPartners(){
    return this.api.getAll();
  }
  
  postHighCompensatedPartners(highCompensatedPartner:HighCompensatedPartners){
    var body = JSON.stringify(highCompensatedPartner);
    return this.api.postData(body);  
  }
  
  putHighCompensatedPartners(highCompensatedPartner:HighCompensatedPartners){
    var body = JSON.stringify(highCompensatedPartner);
    return this.api.putData(body,highCompensatedPartner.HighCompensatedPartnerID.toString());  
  }
}
