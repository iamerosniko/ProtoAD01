import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { HoursReducedLawyers } from '../entities/aba-entities';
@Injectable()
export class HoursReducedLawyersService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("HoursReducedLawyers")
  }

  getHoursReducedLawyers(){
    return this.api.getAll();
  }
  
  postHoursReducedLawyers(hoursReducedLawyer: HoursReducedLawyers){
    var body = JSON.stringify(hoursReducedLawyer);
    return this.api.postData(body);  
  }
}
