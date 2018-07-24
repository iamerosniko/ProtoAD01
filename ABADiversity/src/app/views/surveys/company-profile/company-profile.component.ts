import { Component, OnInit,Output,EventEmitter,Input  } from '@angular/core';
import { CPEntities } from '../entities/companyProfile';
import { FormBuilder, FormGroup, Validators,FormArray } from '@angular/forms';

@Component({
  selector: 'app-company-profile',
  templateUrl: './company-profile.component.html',
  styleUrls: ['./company-profile.component.css']
})
export class CompanyProfileComponent implements OnInit {
  @Output() updateChildFormToParent = new EventEmitter<any>();
  CPdata:CPEntities={};
  myForm: FormGroup;


  // print(){
  //   console.log("joeniel");
  //   console.log(this.CPdata);
  // }  
  // sizecat1(){
  //   this.CPdata.sizecat = 1 
  // }
  // sizecat2(){
  //   this.CPdata.sizecat = 2
  // }
  // sizecat3(){
  //   this.CPdata.sizecat = 3
  // }
  // sizecat4(){
  //   this.CPdata.sizecat = 4
  // }
  // sizecat5(){
  //   this.CPdata.sizecat = 5
  // }

  constructor( private fb:FormBuilder) {
    this.myForm = this.fb.group({
      
      Name : [this.CPdata.firmname,Validators.required]
          
      })
   }

  ngOnInit() {
    // console.log("joeniel")
  }
  sendthistoparent(){
   
    this.updateChildFormToParent.emit(this.myForm)
      }
}
