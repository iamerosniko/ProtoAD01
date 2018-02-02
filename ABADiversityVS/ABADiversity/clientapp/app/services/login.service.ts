import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { MyToken } from '../entities/my-token';
import { Observable} from 'rxjs';
@Injectable()
export class LoginService {

  constructor(private api:ClientApiService) {
    api.normalHeader();
  }
  a : MyToken;
  generateToken(){
    this.api.apiUrl=ClientApiSettings.GETAPIURL("GenerateToken");
    var res = this.api.getAll()
    // console.log(<MyToken>res);
    return res;
  }

  getCurrentToken(){
    this.api.apiUrl=ClientApiSettings.GETAPIURL("GetCurrentToken");
    var res = this.api.getAll()
    return res;
  }
  
}
