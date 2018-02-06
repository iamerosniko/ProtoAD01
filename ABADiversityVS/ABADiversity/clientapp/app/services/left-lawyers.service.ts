import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { LeftLawyers } from '../entities/aba-entities';
@Injectable()
export class LeftLawyersService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("LeftLawyers")
  }
  
  getLeftLawyers(){
    return this.api.getAll();
  }
  
  postLeftLawyers(leftLawyer:LeftLawyers){
    var body = JSON.stringify(leftLawyer);
    return this.api.postData(body);  
  }
}
