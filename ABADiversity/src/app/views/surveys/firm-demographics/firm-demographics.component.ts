import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { isNumber } from 'util'; 
import { FDdetails,FDInfo } from '../entities/firmdemographics'

@Component({
  selector: 'app-firm-demographics',
  templateUrl: './firm-demographics.component.html',
  styleUrls: ['./firm-demographics.component.css']
})
export class FirmDemographicsComponent implements OnInit {
  @Output() updateChildFormToParent = new EventEmitter<any>();
  // application:Applications={}
  // myForm: FormGroup;
  sampledata:FDdetails[]=[
    {equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"Hispanic/Latino",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"Alaska Native/American Indian",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"Asian",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"Native Hawaiian/Other Pacific Islander",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"Multiracial",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"White",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"LGBT",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"Disabled",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"Women",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"},
    {regionName:"Men",equityPartners:"1",nonEquityPartners:"2",associates:"3",counsel:"4",otherLawyers:"5"}
]
sampledata1:FDdetails[]=[{regionName:"African American/Black(not Hispanic/Latino)"}]
  // sampledata1:string = this.sampledata.associates
  

  firmDemo:string[]=['Equity Partners','Non-Equity Partners','Associates','Counsel','Other Lawyers','Totals']
  firmDemoassign:string[]=['EquityPartners','NonEquityPartners','Associates','Counsel','OtherLawyers','Totals']

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
  constructor(private fb:FormBuilder) {
    
  }
  ngOnInit() {
    this.myForm = this.fb.group
    ({
      regions: this.fb.array([]),
      firmID:[1001,Validators.required]
    })
    this.addRow();

    this.myForm.valueChanges.subscribe(()=>{
      console.log('t')
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
    // Here, we make the form for each day
    return this.fb.group({
      region:[name],
      'EquityPartners':[0,Validators.required],
      'NonEquityPartners': [0,Validators.required],
      'Associates': [0, Validators.required ],
      'Counsel': [0,Validators.required ],
      'OtherLawyers': [0,Validators.required],
      // add firmid
    });

    // var samp : any = {regionName : 'america', equityPartners : "1"}
    
  }

  sample(index:number){
    const control = <FormArray>this.myForm.controls['regions'];
    const formb=<FormGroup>control.at(index)
    return (formb.controls['region'].value)
    // console.log(formbuild)
    // return formbuild.control['validate'].value
    //return control[index].controls['validate'].value
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

  submit(){
    console.log(this.myForm.value)
    const control = <FormArray>this.myForm.controls['regions'];
    for(var i =0;i<control.length;i++){
      const demographics =<FormGroup> control.at(i);

      this.firmDemo.forEach(element => {
        if(element!='Totals')
        console.log(element +' ' +demographics.controls[element].value)
      });
    }
  }
}
