import { Component, OnInit, Output, EventEmitter,Input,OnChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { isNumber } from 'util'; 
import { FirmDemographics } from '../../../entities/entities';
import { UUID } from '../../../../../node_modules/angular2-uuid';
import { SurveyService } from '../../../services/survey.service'

@Component({
  selector: 'app-firm-demographics',
  templateUrl: './firm-demographics.component.html',
  styleUrls: ['./firm-demographics.component.css']
})
export class FirmDemographicsComponent implements OnInit,OnChanges {
  @Output() updateChildFormToParent = new EventEmitter<any>();
  @Input() companyProfileID : string ;

  firmDemo:string[]=['Equity Partners','Non-Equity Partners','Associates','Counsel','Other Lawyers','Totals']
  firmDemoassign:string[]=['EquityPartners','NonEquityPartners','Associates','Counsel','OtherLawyers','Totals']
  isExisting:boolean=false;
  firmDemographics:FirmDemographics[]=[]
  items:string[]=
  [
    'African American/Black(not Hispanic/Latino)',
    'Hispanic/Latino',
    'Alaska Native/American Indian',
    'Asian',
    'Native Hawaiian/Other Pacific Islander',
    'Multiracial',
    'White',
    'LGBT',
    'Disabled',
    'Women',
    'Men'
  ]

  myForm: FormGroup;
  constructor(private surveySvc:SurveyService, private fb:FormBuilder) {
  }

  ngOnChanges(){
    this.getValue();
  }

  async getValue(){
    var fd = await this.surveySvc.getSurvey(this.companyProfileID,2);
    this.isExisting = fd ? true : false ;
    this.firmDemographics = fd ? fd : [];
    this.initializeForm();
  }

  initializeForm(){
    this.myForm = this.fb.group
    ({
      regions: this.fb.array([]),
    })
    this.addRow();
    this.updateChildFormToParent.emit(this.myForm)

    this.myForm.valueChanges.subscribe(()=>{
      this.updateChildFormToParent.emit(this.myForm)
      const control = <FormArray>this.myForm.controls['regions'];
      for(var i =0;i<control.length;i++){
        const demographics =<FormGroup> control.at(i);

        this.firmDemoassign.forEach(element => {
          if(element!='Totals'){
            if(demographics.controls[element].invalid){
              demographics.controls[element].setValue(0)
            }
          }
        });


      }
    })
  }

  ngOnInit() {
    this.initializeForm();
  }
  addRow(){
    //1.get the value of formarray that has name regions
    // this.myForm = this.fb.group({
    //   regions: this.fb.array([])    < -- eto un
    // })
    const control = <FormArray>this.myForm.controls['regions'];

    //2.since walang laman ung nakuha nyang formarray.. lalagyan nya un syempre
    
    //loop items to element 
    //ung items un ung mga name sa unang column ng form na ginawa ko 
    this.items.forEach(element => {
      control.push(this.initItems(element));
    });
    
  }
  
  initItems(name:string): FormGroup{
    var fd = this.firmDemographics.find(x=>x.regionName==name);

    if(fd==null){
      // return this.fb.group({
      //   'companyProfileID': [this.companyProfileID,Validators.required],
      //   firmDemographicID:[UUID.UUID(),Validators.required],
      //   regionName:[name],
      //   'EquityPartners':[0,Validators.required],
      //   'NonEquityPartners': [0,Validators.required],
      //   'Associates': [0, Validators.required ],
      //   'Counsel': [0,Validators.required ],
      //   'OtherLawyers': [0,Validators.required],
      // });
      //mockup
      return this.fb.group({
        'companyProfileID': [this.companyProfileID,Validators.required],
        firmDemographicID:[UUID.UUID(),Validators.required],
        regionName:[name],
        'EquityPartners':[Math.floor((Math.random() * 10) + 1),Validators.required],
        'NonEquityPartners': [Math.floor((Math.random() * 10) + 1),Validators.required],
        'Associates': [Math.floor((Math.random() * 10) + 1), Validators.required ],
        'Counsel': [Math.floor((Math.random() * 10) + 1),Validators.required ],
        'OtherLawyers': [Math.floor((Math.random() * 10) + 1),Validators.required],
      });
    }
    else{
      return this.fb.group({
        'companyProfileID': [this.companyProfileID,Validators.required],
        firmDemographicID:[UUID.UUID(),Validators.required],
        regionName:[name],
        'EquityPartners':[fd.equityPartners,Validators.required],
        'NonEquityPartners': [fd.nonEquityPartners,Validators.required],
        'Associates': [fd.associates, Validators.required ],
        'Counsel': [fd.counsel,Validators.required ],
        'OtherLawyers': [fd.otherLawyers,Validators.required],
      });
    }
    // Here, we make the form for each day
  }

  compute(index : number){
    const control = <FormArray>this.myForm.controls['regions'];
    const formb=<FormGroup>control.at(index)
    var value:number=0;
   
      this.firmDemoassign.forEach(element => {
        if(element!='Totals'){
          var a =+formb.controls[element].value
       
          value=value + ((a==null)||!isNumber(a)?0:a)
        }
      });
    return value;
  }

  // submit(){
  //   console.log(this.myForm.value)
  //   const control = <FormArray>this.myForm.controls['regions'];
  //   for(var i =0;i<control.length;i++){
  //     const demographics =<FormGroup> control.at(i);

  //     this.firmDemo.forEach(element => {
  //       if(element!='Totals')
  //       console.log(element +' ' +demographics.controls[element].value)
  //     });
  //   }
  // }
}
