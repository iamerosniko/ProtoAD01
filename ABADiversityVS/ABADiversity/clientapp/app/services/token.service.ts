import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { MyToken } from '../entities/my-token';
import { Observable} from 'rxjs';
@Injectable()
export class TokenService {

  constructor(private api:ClientApiService) {
    api.apiUrl=ClientApiSettings.GETAPIURL("MyToken");
    api.normalHeader();
  }
  a : MyToken;
  async getAuth(){
    var res = this.api.getAll()
    // console.log(<MyToken>res);
    return res;
  }
}
