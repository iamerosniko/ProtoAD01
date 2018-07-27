import { Component, OnInit, ViewChild, Output, EventEmitter, Input } from '@angular/core';
import { FirmDemographicsComponent } from '../firm-demographics/firm-demographics.component';
import { FormBuilder, FormGroup, Validators,FormArray } from '@angular/forms';
import { CompanyProfileComponent } from '../company-profile/company-profile.component';
import { CPEntities } from '../entities/companyProfile';
import { firmlist } from '../entities/firm';
import { Router } from '@angular/router';
import { FDdetails,FDInfo } from '../entities/firmdemographics';

@Component({
  selector: 'app-survey-body',
  templateUrl: './survey-body.component.html',
  styleUrls: ['./survey-body.component.css']
})
export class SurveyBodyComponent implements OnInit {
  formFromChild:FormGroup;
  formFromChild1:FormGroup;
  formFromChild2:FormGroup;
  formFromChild3:FormGroup;
  formFromChild4:FormGroup;
  formFromChild5:FormGroup;
  formFromChild6:FormGroup;
  formFromChild7:FormGroup;
  formFromChild8:FormGroup;
  myForm:FormGroup;

  getChild(event:any){
    this.formFromChild = event;
    console.log('Company Profile')
    console.log(this.formFromChild.value)
    this.myForm.controls['CompanyProfile'].setValue(event)
  }
  getChild1(event:any){
    this.formFromChild1 = event;
    console.log('Overall Firm Demographics')
    console.log(this.formFromChild1.value)
    this.myForm.controls['FirmDemographics'].setValue(event)
  }
  getChild2(event:any){
    this.formFromChild2 = event;
    console.log('Firm Leadership/Management Demographic Profile')
    console.log(this.formFromChild2.value)
    this.myForm.controls['LeadershipDemographics'].setValue(event)
  }
  getChild3(event:any){
    this.formFromChild3 = event;
    console.log('Number of Promotions from Associate to Partner')
    console.log(this.formFromChild3.value)
    this.myForm.controls['PromotionsAssociatePartners'].setValue(event)
  }
  getChild4(event:any){
    this.formFromChild4 = event;
    console.log('Lawyers Who Left The Firm')
    console.log(this.formFromChild4.value)
    this.myForm.controls['LeftLawyers'].setValue(event)
  }
  getChild5(event:any){
    this.formFromChild5 = event;
    console.log('Hires')
    console.log(this.formFromChild5.value)
    this.myForm.controls['JoinedLawyers'].setValue(event)
  }
  getChild6(event:any){
    this.formFromChild6 = event;
    console.log('Lawyers Working Reduced Hours Schedule')
    console.log(this.formFromChild6.value)
    this.myForm.controls['ReducedHoursLawyers'].setValue(event)
  }
  getChild7(event:any){
    this.formFromChild7 = event;
    console.log('Top 10% Highest Compensated Partners')
    console.log(this.formFromChild7.value)
    this.myForm.controls['TopTenHighestCompensations'].setValue(event)
  }
  getChild8(event:any){
    this.formFromChild8 = event;
    console.log('Undertaken Initiatives/Actions')
    console.log(this.formFromChild8.value)
    this.myForm.controls['UndertakenInitiatives'].setValue(event)
  }

  // parse1(){
  //   this.trial1 = this.formFromChild1.value(0)
  // }

  // constructor() { }
constructor( private fb:FormBuilder) {
    this.myForm = this.fb.group({
      CompanyProfile:[this.formFromChild, Validators.required],
      FirmDemographics:[this.formFromChild1, Validators.required],
      LeadershipDemographics:[this.formFromChild2, Validators.required],
      PromotionsAssociatePartners:[this.formFromChild3, Validators.required],
      LeftLawyers:[this.formFromChild4, Validators.required],
      JoinedLawyers:[this.formFromChild5, Validators.required],
      ReducedHoursLawyers:[this.formFromChild6, Validators.required],
      TopTenHighestCompensations:[this.formFromChild7, Validators.required],
      UndertakenInitiatives:[this.formFromChild8, Validators.required]      
    });
   }
  ngOnInit() {
    
  }
  async save(){

  }
}
