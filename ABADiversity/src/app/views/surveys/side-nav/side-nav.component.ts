import { Component, OnInit, ViewChild, Output, EventEmitter, Input, NgModule} from '@angular/core';
import { FirmDemographicsComponent } from '../firm-demographics/firm-demographics.component';
import { FormBuilder, FormGroup, Validators,FormArray } from '@angular/forms';
import { CompanyProfileComponent } from '../company-profile/company-profile.component';
import { CPEntities } from '../entities/companyProfile';
import { firmlist } from '../entities/firm';
import { Router } from '@angular/router';
import { SurveyBodyComponent } from '../survey-body/survey-body.component'

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {
  firmlist:firmlist[]=[
    {firmcode: 'MNULFE1001'},
    {firmcode: 'PSSCPH1001'},
    {firmcode: 'BDOMPH1001'},
    {firmcode: 'SECBPH1001'}
]
firmlistoriginal:firmlist[]=[
  {firmcode: 'MNULFE1001'},
  {firmcode: 'PSSCPH1001'},
  {firmcode: 'BDOMPH1001'},
  {firmcode: 'SECBPH1001'}
]
  firmSearchList:firmlist[]=[]
  firmSearch:firmlist={}
  // firmSearch1:
  // CPdata:CPEntities={};
  // myForm: FormGroup;
  addFirm(){
    console.log("Hello")

  }
  searchFirm(){

    console.log("Search")

    this.firmlist.forEach(element => {
      if(element.firmcode == this.firmSearch.firmSearch){
        console.log("happy")
        this.firmlist = this.firmSearchList
        this.firmlist.forEach(element =>(element.firmcode =  this.firmSearch.firmSearch))
      }
      else{console.log("sad")}
    });
    console.log(this.firmSearch.firmSearch)
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
