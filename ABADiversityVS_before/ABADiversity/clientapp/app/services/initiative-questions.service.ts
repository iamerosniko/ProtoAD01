import { Injectable } from '@angular/core';

import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 

@Injectable()
export class InitiativeQuestionsService {

  constructor(private api:ClientApiService) {
    api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("InitiativeQuestions")
  }

  getQuestions(){
    return this.api.getAll()
  }

}
