import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
@Injectable()
export class LoginService {

  constructor(private api:ClientApiService) {
    api.normalHeader();
  }

  getCurrentToken(){
    this.api.apiUrl=ClientApiSettings.GETCLIENTAPIURL("GetCurrentToken");
    var res = this.api.getAll()
    return res;
  }

  GetAuthenticationToken(){
    this.api.apiUrl=ClientApiSettings.GETCLIENTAPIURL("ProvideAuthenticationToken");
    var res = this.api.getAll()
    // console.log(<MyToken>res);
    return res;
  }

  GetAuthorizationToken(){
    this.api.apiUrl=ClientApiSettings.GETCLIENTAPIURL("ProvideAuthorizationToken");
    var res = this.api.getAll()
    // console.log(<MyToken>res);
    return res;
  }

  Logout(){
    this.api.apiUrl=ClientApiSettings.GETCLIENTAPIURL("Logout");
    this.api.getAll();
  }
  
  GetCurrentUser(token:string){
    this.api.apiUrl=ClientApiSettings.GETCLIENTAPIURL("TokenToDetails");
    var token1 = {'Token':token}
    var currentUser = this.api.postData(JSON.stringify(token1));

    return (currentUser)
  }
}
