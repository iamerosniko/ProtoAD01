import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(){

  }

  // a:any;
  ngOnInit(){
  //   this.get();
  }
  
  // async get(){
  //   console.log( await this.token.GetAuthenticationToken());
  //   console.log( await this.token.getCurrentToken())
  // }
}
