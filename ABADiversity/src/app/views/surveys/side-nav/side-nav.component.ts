import { Component, OnInit, ViewChild, Output, EventEmitter, Input, NgModule} from '@angular/core';
import { Firms } from '../../../entities/entities';
import { Router } from '@angular/router';
import { SurveyService } from '../../../services/survey.service';
@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {
  firmlist:Firms[]=[];
  firmSearchList:Firms[]=[]
  firmSearch:Firms={}

  constructor(private router:Router,private surveySvc : SurveyService) { }

  async getFirms(){
    this.firmlist = <Firms[]> await this.surveySvc.getFirms();
    console.log(this.firmlist)
  }

  searchFirm(){

    console.log("Search")

    this.firmlist.forEach(element => {
      if(element.firmID == this.firmSearch.firmName){
        console.log("happy")
        this.firmlist = this.firmSearchList
        this.firmlist.forEach(element =>(element.firmID =  this.firmSearch.firmName))
      }
      else{console.log("sad")}
    });
    console.log(this.firmSearch.firmName)
    console.log(this.firmlist)
    
  }
  
  async ngOnInit() {
    await this.getFirms();
  }

}
