import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../../services/aba.services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginService :LoginService,private router: Router) { }

  ngOnInit() {
    this.Login();
  }

  async Login(){
    var authenticationToken = await this.loginService.GetAuthenticationToken();
    var authorizationToken = await this.loginService.GetAuthorizationToken();    
    // console.log('authenticationToken : '+ authenticationToken)
    // console.log('Authorization : '+ authorizationToken)
    await sessionStorage.setItem("AuthToken",authenticationToken);
    await sessionStorage.setItem("ApiToken",authorizationToken);

    setTimeout(() => {
      this.router.navigate(['./Redirecting']) 
    }, 3000);
  }
}
