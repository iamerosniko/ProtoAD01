import { Component,OnInit } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { Subscription,Subject,BehaviorSubject } from 'rxjs/';
import 'rxjs/add/observable/interval';
import { observeOn } from 'rxjs/operators/observeOn';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  
  constructor(){
    setInterval(()=>{
      if(sessionStorage.getItem('Cache3')!=null){

      }
    },1000);
    
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
