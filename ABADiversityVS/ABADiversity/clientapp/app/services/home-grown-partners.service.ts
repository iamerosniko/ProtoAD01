import { Injectable } from '@angular/core';

import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { HomegrownPartners } from '../entities/aba-entities';

@Injectable()
export class HomeGrownPartnersService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("HomeGrownPartners")
  }

  getHomeGrownPartners(){
    return this.api.getAll()
  }

  postHomeGrownPartners(homeGrownPartner:HomegrownPartners){
    var body = JSON.stringify(homeGrownPartner);
    return this.api.postData(body);  
  }

  putHomeGrownPartners(homeGrownPartner:HomegrownPartners){
    var body = JSON.stringify(homeGrownPartner);
    return this.api.putData(body,homeGrownPartner.HomegrownPartnersID.toString());  
  }
}
