
import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 


@Injectable()
export class SurveyService {

  constructor(private api:ClientApiService) {
    //uncomment api.authorizedHeader() if AD Authentication is enabled.
    //use api.normalHeader() if anonymous authentication is enabled.
    //api.authorizedHeader();
  }

  // getSurveys() {
  //   this.api.normalHeader();
  //   this.api.apiUrl=ClientApiSettings.GETBWURL("FESurvey")
  //   return this.api.getAll();
  // }

  getSurvey(applicationID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FESurvey")
    return this.api.getOne(applicationID);
  }

  postSurvey(application: any) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FESurvey")
    var body = JSON.stringify(application);
    return this.api.postData(body);
  } 

  putSurvey(application: any) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FESurvey")
    var body = JSON.stringify(application);
    return this.api.putData(application.AppID.toString(),body );
  }

  // deleteSurvey(applicationID: string) {
  //   this.api.normalHeader();
  //   this.api.apiUrl=ClientApiSettings.GETBWURL("FESurvey")
  //   return this.api.deleteData(applicationID);
  // }
}
