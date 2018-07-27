import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { JoinedLawyers } from '../entities/aba-entities';
@Injectable()
export class JoinedLawyersService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("JoinedLawyers")
  }

  getJoinedLawyers(){
    return this.api.getAll();
  }

  postJoinedLawyers(joinedLawyer: JoinedLawyers){
    var body = JSON.stringify(joinedLawyer);
    return this.api.postData(body);  
  }

  putJoinedLawyers(joinedLawyer: JoinedLawyers){
    var body = JSON.stringify(joinedLawyer);
    return this.api.putData(body,joinedLawyer.JoinedLawyerID.toString());  
  }
}
