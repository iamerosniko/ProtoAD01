import { Component, OnInit,Output,EventEmitter,Input, state  } from '@angular/core';
import { initiatives, commentsdata } from '../entities/undertakeninitiatives';
import { FormBuilder, FormGroup, Validators,FormArray } from '@angular/forms';

@Component({
  selector: 'app-undertaken-initiatives',
  templateUrl: './undertaken-initiatives.component.html',
  styleUrls: ['./undertaken-initiatives.component.css']
})
export class UndertakenInitiativesComponent implements OnInit {
  @Output() updateChildFormToParent = new EventEmitter<any>();
  initData:initiatives={};
  myForm: FormGroup;
  commentsForm: FormGroup;
  // tempComment:commentsdata={}
  tempComments:commentsdata={};

  rdb1Condition:boolean = true;
  rdb2Condition:boolean = true;
  rdb3Condition:boolean = true;
  rdb4Condition:boolean = true;
  rdb5Condition:boolean = true;
  rdb6Condition:boolean = true;
  rdb7Condition:boolean = true;
  rdb8Condition:boolean = true;
  rdb9Condition:boolean = true;
  rdb10Condition:boolean = true;
  rdb11Condition:boolean = true;
  rdb12Condition:boolean = true;
  rdb13Condition:boolean = true;
  rdb14Condition:boolean = true;
  rdb15Condition:boolean = true;
  rdb16Condition:boolean = true;
  rdb17Condition:boolean = true;

  // rdbChange(status:boolean){
  //   this.rdb1Condition=status;
  // }
  rdb1yesclick(){
    this.rdb1Condition = true;
    this.tempComments.q1c = null;
  }
  rdb1noclick(){
    this.rdb1Condition = false;
    // console.log(this.tempComments.q1c)
  }
  rdb2yesclick(){
    this.rdb2Condition = true;
    this.tempComments.q2c = null;
  }
  rdb2noclick(){
    this.rdb2Condition = false;
  }
  rdb3yesclick(){
    this.rdb3Condition = true;
    this.tempComments.q3c = null;
  }
  rdb3noclick(){
    this.rdb3Condition = false;
  }
  rdb4yesclick(){
    this.rdb4Condition = true;
    this.tempComments.q4c = null;
  }
  rdb4noclick(){
    this.rdb4Condition = false;
  }
  rdb5yesclick(){
    this.rdb5Condition = true;
    this.tempComments.q5c = null;
  }
  rdb5noclick(){
    this.rdb5Condition = false;
  }
  rdb6yesclick(){
    this.rdb6Condition = true;
    this.tempComments.q6c = null;
  }
  rdb6noclick(){
    this.rdb6Condition = false;
  }
  rdb7yesclick(){
    this.rdb7Condition = true;
    this.tempComments.q7c = null;
  }
  rdb7noclick(){
    this.rdb7Condition = false;
  }
  rdb8yesclick(){
    this.rdb8Condition = true;
    this.tempComments.q8c = null;
  }
  rdb8noclick(){
    this.rdb8Condition = false;
  }
  rdb9yesclick(){
    this.rdb9Condition = true;
    this.tempComments.q9c = null;
  }
  rdb9noclick(){
    this.rdb9Condition = false;
  }
  rdb10yesclick(){
    this.rdb10Condition = true;
    this.tempComments.q10c = null;
  }
  rdb10noclick(){
    this.rdb10Condition = false;
  }
  rdb11yesclick(){
    this.rdb11Condition = true;
    this.tempComments.q11c = null;
  }
  rdb11noclick(){
    this.rdb11Condition = false;
  }
  rdb12yesclick(){
    this.rdb12Condition = true;
    this.tempComments.q12c = null;
  }
  rdb12noclick(){
    this.rdb12Condition = false;
  }
  rdb13yesclick(){
    this.rdb13Condition = true;
    this.tempComments.q13c = null;
  }
  rdb13noclick(){
    this.rdb13Condition = false;
  }
  rdb14yesclick(){
    this.rdb14Condition = true;
    this.tempComments.q14c = null;
  }
  rdb14noclick(){
    this.rdb14Condition = false;
  }
  rdb15yesclick(){
    this.rdb15Condition = true;
    this.tempComments.q15c = null;
  }
  rdb15noclick(){
    this.rdb15Condition = false
  }
  rdb16yesclick(){
    this.rdb16Condition = true;;
    this.tempComments.q16c = null;
  }
  rdb16noclick(){
    this.rdb16Condition = false;
  }
  rdb17yesclick(){
    this.rdb17Condition = true;
    this.tempComments.q17c = null;
  }
  rdb17noclick(){
    this.rdb17Condition = false;
  }
  
  constructor(private fb:FormBuilder) { 
    this.myForm = this.fb.group({
      q1:[this.initData.q1,Validators.required],
      q2:[this.initData.q2,Validators.required],
      q3:[this.initData.q3,Validators.required],
      q4:[this.initData.q4,Validators.required],
      q5:[this.initData.q5,Validators.required],
      q6:[this.initData.q6,Validators.required],
      q7:[this.initData.q7,Validators.required],
      q8:[this.initData.q8,Validators.required],
      q9:[this.initData.q9,Validators.required],
      q10:[this.initData.q10,Validators.required],
      q11:[this.initData.q11,Validators.required],
      q12:[this.initData.q12,Validators.required],
      q13:[this.initData.q13,Validators.required],
      q14:[this.initData.q14,Validators.required],
      q15:[this.initData.q15,Validators.required],
      q16:[this.initData.q16,Validators.required],
      q17:[this.initData.q17,Validators.required],
      comments:[this.initData.comments,Validators.required],

      qComment:[this.commentsForm = this.fb.group({
        qComments : [ 
          this.tempComments
        ]
      })],
      // q2c:[this.tempComments.q2c,Validators.required],
      // q3c:[this.tempComments.q3c,Validators.required],
      // q4c:[this.tempComments.q4c,Validators.required],
      // q5c:[this.tempComments.q5c,Validators.required],
      // q6c:[this.tempComments.q6c,Validators.required],
      // q7c:[this.tempComments.q7c,Validators.required],
      // q8c:[this.tempComments.q8c,Validators.required],
      // q9c:[this.tempComments.q9c,Validators.required],
      // q10c:[this.tempComments.q10c,Validators.required],
      // q11c:[this.tempComments.q11c,Validators.required],
      // q12c:[this.tempComments.q12c,Validators.required],
      // q13c:[this.tempComments.q13c,Validators.required],
      // q14c:[this.tempComments.q14c,Validators.required],
      // q15c:[this.tempComments.q15c,Validators.required],
      // q16c:[this.tempComments.q16c,Validators.required],
      // q17c:[this.tempComments.q17c,Validators.required],
    });
    this.myForm.valueChanges.subscribe(()=>{
      this.sendthistoparent();
    });
   }
  ngOnInit() {
    
  }
  sendthistoparent(){
    this.updateChildFormToParent.emit(this.myForm)
      }

}
