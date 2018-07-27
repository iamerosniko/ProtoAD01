import { Component, OnInit,Output,EventEmitter,Input, state  } from '@angular/core';
import { UndertakenInitiatives } from '../../../entities/entities';
import { FormBuilder, FormGroup, Validators,FormArray } from '@angular/forms';

@Component({
  selector: 'app-undertaken-initiatives',
  templateUrl: './undertaken-initiatives.component.html',
  styleUrls: ['./undertaken-initiatives.component.css']
})
export class UndertakenInitiativesComponent implements OnInit {
  @Output() updateChildFormToParent = new EventEmitter<any>();
  initData:UndertakenInitiatives={};
  myForm: FormGroup;
  commentsForm: FormGroup;
  // tempComment:commentsdata={}
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
    this.initData.comment1 = null;
  }
  rdb1noclick(){
    this.rdb1Condition = false;
    // console.log(this.tempComments.q1c)
  }
  rdb2yesclick(){
    this.rdb2Condition = true;
    this.initData.comment1 = null;
  }
  rdb2noclick(){
    this.rdb2Condition = false;
  }
  rdb3yesclick(){
    this.rdb3Condition = true;
    this.initData.comment1 = null;
  }
  rdb3noclick(){
    this.rdb3Condition = false;
  }
  rdb4yesclick(){
    this.rdb4Condition = true;
    this.initData.comment1 = null;
  }
  rdb4noclick(){
    this.rdb4Condition = false;
  }
  rdb5yesclick(){
    this.rdb5Condition = true;
    this.initData.comment1 = null;
  }
  rdb5noclick(){
    this.rdb5Condition = false;
  }
  rdb6yesclick(){
    this.rdb6Condition = true;
    this.initData.comment1 = null;
  }
  rdb6noclick(){
    this.rdb6Condition = false;
  }
  rdb7yesclick(){
    this.rdb7Condition = true;
    this.initData.comment1 = null;
  }
  rdb7noclick(){
    this.rdb7Condition = false;
  }
  rdb8yesclick(){
    this.rdb8Condition = true;
    this.initData.comment1 = null;
  }
  rdb8noclick(){
    this.rdb8Condition = false;
  }
  rdb9yesclick(){
    this.rdb9Condition = true;
    this.initData.comment1 = null;
  }
  rdb9noclick(){
    this.rdb9Condition = false;
  }
  rdb10yesclick(){
    this.rdb10Condition = true;
    this.initData.comment1 = null;
  }
  rdb10noclick(){
    this.rdb10Condition = false;
  }
  rdb11yesclick(){
    this.rdb11Condition = true;
    this.initData.comment1 = null;
  }
  rdb11noclick(){
    this.rdb11Condition = false;
  }
  rdb12yesclick(){
    this.rdb12Condition = true;
    this.initData.comment1 = null;
  }
  rdb12noclick(){
    this.rdb12Condition = false;
  }
  rdb13yesclick(){
    this.rdb13Condition = true;
    this.initData.comment1 = null;
  }
  rdb13noclick(){
    this.rdb13Condition = false;
  }
  rdb14yesclick(){
    this.rdb14Condition = true;
    this.initData.comment1 = null;
  }
  rdb14noclick(){
    this.rdb14Condition = false;
  }
  rdb15yesclick(){
    this.rdb15Condition = true;
    this.initData.comment1 = null;
  }
  rdb15noclick(){
    this.rdb15Condition = false
  }
  rdb16yesclick(){
    this.rdb16Condition = true;;
    this.initData.comment1 = null;
  }
  rdb16noclick(){
    this.rdb16Condition = false;
  }
  rdb17yesclick(){
    this.rdb17Condition = true;
    this.initData.comment1 = null;
  }
  rdb17noclick(){
    this.rdb17Condition = false;
  }
  
  constructor(private fb:FormBuilder) { 
    this.myForm = this.fb.group({
      answer1:[this.initData.answer1,Validators.required],
      answer2:[this.initData.answer2,Validators.required],
      answer3:[this.initData.answer3,Validators.required],
      answer4:[this.initData.answer4,Validators.required],
      answer5:[this.initData.answer5,Validators.required],
      answer6:[this.initData.answer6,Validators.required],
      answer7:[this.initData.answer7,Validators.required],
      answer8:[this.initData.answer8,Validators.required],
      answer9:[this.initData.answer9,Validators.required],
      answer10:[this.initData.answer10,Validators.required],
      answer11:[this.initData.answer11,Validators.required],
      answer12:[this.initData.answer12,Validators.required],
      answer13:[this.initData.answer13,Validators.required],
      answer14:[this.initData.answer14,Validators.required],
      answer15:[this.initData.answer15,Validators.required],
      answer16:[this.initData.answer16,Validators.required],
      answer17:[this.initData.answer17,Validators.required],
      mainComment:[this.initData.mainComment,Validators.required],
      comment1:[this.initData.comment1,Validators.required],
      comment2:[this.initData.comment2,Validators.required],
      comment3:[this.initData.comment3,Validators.required],
      comment4:[this.initData.comment4,Validators.required],
      comment5:[this.initData.comment5,Validators.required],
      comment6:[this.initData.comment6,Validators.required],
      comment7:[this.initData.comment7,Validators.required],
      comment8:[this.initData.comment8,Validators.required],
      comment9:[this.initData.comment9,Validators.required],
      comment10:[this.initData.comment10,Validators.required],
      comment11:[this.initData.comment11,Validators.required],
      comment12:[this.initData.comment12,Validators.required],
      comment13:[this.initData.comment13,Validators.required],
      comment14:[this.initData.comment14,Validators.required],
      comment15:[this.initData.comment15,Validators.required],
      comment16:[this.initData.comment16,Validators.required],
      comment17:[this.initData.comment17,Validators.required],
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
