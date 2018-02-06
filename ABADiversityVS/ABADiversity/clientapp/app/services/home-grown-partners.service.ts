import { Injectable } from '@angular/core';

import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 

@Injectable()
export class HomeGrownPartnersService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("HomeGrownPartners")
  }

  getHomeGrownPartners(){
    return this.api.getAll()
  }

}
