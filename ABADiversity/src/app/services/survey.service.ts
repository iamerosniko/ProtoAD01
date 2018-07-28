
import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { Survey } from '../entities/survey';

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

  getFirms(){
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("Firms")
    return this.api.getAll();
  }

  getSurvey(applicationID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("Survey")
    return this.api.getOne(applicationID);
  }

  postSurvey(surveyObj: Survey) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("Survey")
    var body = JSON.stringify(surveyObj);
    return this.api.postData(body);
  } 

  // putSurvey(application: any) {
  //   this.api.normalHeader();
  //   this.api.apiUrl=ClientApiSettings.GETBWURL("Survey")
  //   var body = JSON.stringify(application);
  //   return this.api.putData(application.AppID.toString(),body );
  // }

  // deleteSurvey(applicationID: string) {
  //   this.api.normalHeader();
  //   this.api.apiUrl=ClientApiSettings.GETBWURL("FESurvey")
  //   return this.api.deleteData(applicationID);
  // }
}
