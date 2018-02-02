import { Component,OnInit } from '@angular/core';

import { TokenService } from './services/aba.services';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private token:TokenService){

  }

  a:any;
  ngOnInit(){
    this.get();
  }
  
  async get(){
    console.log( await this.token.getAuth());
  }
}
