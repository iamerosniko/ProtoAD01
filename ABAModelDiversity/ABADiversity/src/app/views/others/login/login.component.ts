import { Component, OnInit } from '@angular/core';
import { ClientLoginService } from '../../../services/client.services';
import { Router } from '@angular/router';
import { EnvironmentSvc } from '../../../services/environments.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private environmentSvc:EnvironmentSvc,
    private loginService :ClientLoginService,
    private router: Router) { }
  ngOnInit() {
    this.Login();
  }

  async Login(){
    var BW =await this.environmentSvc.getBWURL();
    await sessionStorage.setItem("BWAPI",BW.URL)
    console.log(BW.URL);
    // var authenticationToken = await this.loginService.GetAuthenticationToken();
    // var authorizationToken = await this.loginService.GetAuthorizationToken();    
    // // var currentUser = await this.loginService.GetCurrentUser(authenticationToken);
    // await sessionStorage.setItem("Cache0",authenticationToken);
    // await sessionStorage.setItem("Cache1",authorizationToken);
    // await sessionStorage.setItem("Cache2",window.btoa(JSON.stringify(currentUser)));


    setTimeout(async () => {
      this.router.navigate(['./Redirecting']) 
    }, 50);
  }

}
