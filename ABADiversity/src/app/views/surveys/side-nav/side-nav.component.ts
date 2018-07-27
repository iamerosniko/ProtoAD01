import { Component, OnInit, ViewChild, Output, EventEmitter, Input, NgModule} from '@angular/core';
import { Firms } from '../../../entities/entities';
import { Router } from '@angular/router';
import { SurveyBodyComponent } from '../survey-body/survey-body.component'

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {
  firmlist:Firms[]=[
    {firmID: 'MNULFE1001'},
    {firmID: 'PSSCPH1001'},
    {firmID: 'BDOMPH1001'},
    {firmID: 'SECBPH1001'}
]
firmlistoriginal:Firms[]=[
  {firmID: 'MNULFE1001'},
  {firmID: 'PSSCPH1001'},
  {firmID: 'BDOMPH1001'},
  {firmID: 'SECBPH1001'}
]
  firmSearchList:Firms[]=[]
  firmSearch:Firms={}
  // firmSearch1:
  // CPdata:CPEntities={};
  // myForm: FormGroup;
  addFirm(){
    console.log("Hello")

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
  constructor(private router:Router) { }
  
  ngOnInit() {
  //reactiveforms na ang laman ng forms na ito ay forms na kamukha ng nasa bawat component
  // return this.fb.group({
  //   region:[name],
  //   'firmDemographics':[0,Validators.required],
  //   'tab2': [0,Validators.required ],
  //   'tab3': [0, Validators.required ],
  //   'tab4': [0,Validators.required ],
  //   'tab5': [0,Validators.required],
  // });
  }

}
