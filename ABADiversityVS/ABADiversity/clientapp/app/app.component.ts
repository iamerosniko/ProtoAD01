import { Component,OnInit } from '@angular/core';

import { LoginService } from './services/aba.services';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private token:LoginService){

  }

  a:any;
  ngOnInit(){
    this.get();
  }
  
  async get(){
    console.log( await this.token.generateToken());
    console.log( await this.token.getCurrentToken())
  }
}
