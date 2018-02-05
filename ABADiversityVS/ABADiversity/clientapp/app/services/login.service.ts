import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { Observable} from 'rxjs';
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
  
}
