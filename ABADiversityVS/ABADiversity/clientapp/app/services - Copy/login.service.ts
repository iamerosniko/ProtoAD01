import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
@Injectable()
export class LoginService {

  constructor(private api:ClientApiService) {
    api.normalHeader();
  }

  getCurrentToken(){
    this.api.apiUrl=ClientApiSettings.GETAPIURL("GetCurrentToken");
    var res = this.api.getAll()
    return res;
  }

  GetAuthenticationToken(){
    this.api.apiUrl=ClientApiSettings.GETAPIURL("ProvideAuthenticationToken");
    var res = this.api.getAll()
    // console.log(<MyToken>res);
    return res;
  }

  GetAuthorizationToken(){
    this.api.apiUrl=ClientApiSettings.GETAPIURL("ProvideAuthorizationToken");
    var res = this.api.getAll()
    // console.log(<MyToken>res);
    return res;
  }

  Logout(){
    this.api.apiUrl=ClientApiSettings.GETAPIURL("Logout");
    this.api.getAll();
  }
  
  GetCurrentUser(token:string){
    this.api.apiUrl=ClientApiSettings.GETAPIURL("TokenToRoles");
    var token1 = {'Token':token}
    var currentUser = this.api.postData(JSON.stringify(token1));

    return (currentUser)
  }
}
