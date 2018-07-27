import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit {
  constructor() { 
    var interval = setInterval(function(){
      if(sessionStorage.getItem('Cache2')!=null){
        // console.log(sessionStorage.getItem('Cache2'))
      }  
    }, 100); 
  }

  ngOnInit() {
    
  }

  async getName(){
    //return new Promise<string>((res)=>res(this.currentUser.FirstName+' '+this.currentUser.LastName));
    //console.log(this.currentUser)
  }
  

}
