import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../../services/aba.services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginService :LoginService) { }

  ngOnInit() {

  }

  async Login(){
    var authenticationToken = await this.loginService.GetAuthenticationToken();
    var authorizationToken = await this.loginService.GetAuthorizationToken();

    await sessionStorage.setItem("AuthToken",authenticationToken);
    await sessionStorage.setItem("ApiToken",authorizationToken);
  }
}
