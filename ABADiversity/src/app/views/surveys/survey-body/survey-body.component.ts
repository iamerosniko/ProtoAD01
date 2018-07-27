import { Component, OnInit, ViewChild, Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators,FormArray } from '@angular/forms';

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
  }
  getChild1(event:any){
    this.formFromChild1 = event;
    console.log('Overall Firm Demographics')
    console.log(this.formFromChild1.value)
  }
  getChild2(event:any){
    this.formFromChild2 = event;
    console.log('Firm Leadership/Management Demographic Profile')
    console.log(this.formFromChild2.value)
  }
  getChild3(event:any){
    this.formFromChild3 = event;
    console.log('Number of Promotions from Associate to Partner')
    console.log(this.formFromChild3.value)
  }
  getChild4(event:any){
    this.formFromChild4 = event;
    console.log('Lawyers Who Left The Firm')
    console.log(this.formFromChild4.value)
  }
  getChild5(event:any){
    this.formFromChild5 = event;
    console.log('Hires')
    console.log(this.formFromChild5.value)
  }
  getChild6(event:any){
    this.formFromChild6 = event;
    console.log('Lawyers Working Reduced Hours Schedule')
    console.log(this.formFromChild6.value)
  }
  getChild7(event:any){
    this.formFromChild7 = event;
    console.log('Top 10% Highest Compensated Partners')
    console.log(this.formFromChild7.value)
  }
  getChild8(event:any){
    this.formFromChild8 = event;
    console.log('Undertaken Initiatives/Actions')
    console.log(this.formFromChild8.value)
  }

constructor( private fb:FormBuilder) {
   
   }
  ngOnInit() {
    
  }
  
  save(){
    // console.log(this.formFromChild.value)
    // console.log(this.formFromChild1.value)
    // console.log(this.formFromChild2.value)
    // console.log(this.formFromChild3.value)
    // console.log(this.formFromChild4.value)
    // console.log(this.formFromChild5.value)
    // console.log(this.formFromChild6.value)
    // console.log(this.formFromChild7.value)
    // console.log(this.formFromChild8.value)
    console.log(this.formFromChild.valid)
  }

  isValid():boolean{

    var a = this.formFromChild.valid
      // this.formFromChild.valid && 
      // this.formFromChild1.valid && 
      // this.formFromChild2.valid && 
      // this.formFromChild3.valid && 
      // this.formFromChild4.valid &&
      // this.formFromChild5.valid && 
      // this.formFromChild6.valid && 
      // this.formFromChild7.valid; 
    return a;
  }
}
