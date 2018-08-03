import { Component, OnInit, Output, EventEmitter,Input,OnChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { isNumber } from 'util';
import { UUID } from 'angular2-uuid';
import { SurveyService } from '../../../services/survey.service'
import { PromotionsAssociatePartners } from '../../../entities/entities';

@Component({
  selector: 'app-promotions-assoc-partner',
  templateUrl: './promotions-assoc-partner.component.html',
  styleUrls: ['./promotions-assoc-partner.component.css']
})
export class PromotionsAssocPartnerComponent implements OnInit ,OnChanges{
  @Input() companyProfileID : string ;
  @Output() updateChildFormToParent = new EventEmitter<any>();
  firmPromo:string[]=['Equity Partners','Non-Equity Partners','Associates','Counsel','Other Lawyers','Total']
  firmPromoassign:string[]=['EquityPartners','NonEquityPartners','Associates','Counsel','OtherLawyers','Totals']
  isExisting:boolean=false;
  promotionsAssociatePartners:PromotionsAssociatePartners[]=[]

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
    var pap = await this.surveySvc.getSurvey(this.companyProfileID,4);
    this.isExisting = pap ? true : false ;
    this.promotionsAssociatePartners = pap ? pap : [];
    console.log(this.promotionsAssociatePartners )
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
      console.log('t')
      this.updateChildFormToParent.emit(this.myForm)
      const control = <FormArray>this.myForm.controls['regions'];
      for(var i =0;i<control.length;i++){
        const demographics =<FormGroup> control.at(i);

        this.firmPromoassign.forEach(element => {
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
    var pap = this.promotionsAssociatePartners.find(x=>x.regionName==name);

    if(pap==null){
      return this.fb.group({
        'companyProfileID': [this.companyProfileID,Validators.required],
        firmDemographicID:[UUID.UUID(),Validators.required],
        regionName:[name],
        'EquityPartners':[0,Validators.required],
        'NonEquityPartners': [0,Validators.required],
        'Associates': [0, Validators.required ],
        'Counsel': [0,Validators.required ],
        'OtherLawyers': [0,Validators.required],
      });
    }
    else{
      return this.fb.group({
        'companyProfileID': [this.companyProfileID,Validators.required],
        firmDemographicID:[UUID.UUID(),Validators.required],
        regionName:[name],
        'EquityPartners':[pap.equityPartners,Validators.required],
        'NonEquityPartners': [pap.nonEquityPartners,Validators.required],
        'Associates': [pap.associates, Validators.required ],
        'Counsel': [pap.counsel,Validators.required ],
        'OtherLawyers': [pap.otherLawyers,Validators.required],
      });
    }
    // Here, we make the form for each day
  }

  compute(index : number){
    const control = <FormArray>this.myForm.controls['regions'];
    const formb=<FormGroup>control.at(index)
    var value:number=0;
   
      this.firmPromoassign.forEach(element => {
        if(element!='Totals'){
          var a =+formb.controls[element].value
       
          value=value + ((a==null)||!isNumber(a)?0:a)
        }
      });
    return value;
  }

  submit(){
    console.log(this.myForm.value)
    const control = <FormArray>this.myForm.controls['regions'];
    for(var i =0;i<control.length;i++){
      const demographics =<FormGroup> control.at(i);

      this.firmPromo.forEach(element => {
        if(element!='Totals')
        console.log(element +' ' +demographics.controls[element].value)
      });
    }
  }
}
