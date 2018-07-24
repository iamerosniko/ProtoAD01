import { Component, OnInit, ViewChild } from '@angular/core';
import {FirmDemographicsComponent} from '../firm-demographics/firm-demographics.component';
import { FormBuilder, FormGroup, Validators,FormArray } from '@angular/forms';

@Component({
  selector: 'app-save-bar',
  templateUrl: './save-bar.component.html',
  styleUrls: ['./save-bar.component.css']
})
export class SaveBarComponent implements OnInit {
  @ViewChild(FirmDemographicsComponent) FDComponent;
  
  msg1:string;

savebtn(){
  // console.log(FirmDemographicsComponent)
  this.msg1 = 'stop';
  console.log(this.msg1)
  this.msg1= this.FDComponent.msg2
  console.log(this.msg1)
}
  // constructor(private team:) {
  //  }

  ngOnInit() {
    
  }

}
