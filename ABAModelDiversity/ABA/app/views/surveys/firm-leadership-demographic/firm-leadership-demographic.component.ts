import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { isNumber } from 'util';

@Component({
  selector: 'app-firm-leadership-demographic',
  templateUrl: './firm-leadership-demographic.component.html',
  styleUrls: ['./firm-leadership-demographic.component.css']
})
export class FirmLeadershipDemographicComponent implements OnInit {
  firmLead:string[]=['Minority Female','Minority Male','White Female','White Male','LGBT','Disabled','Total']
  firmLeadassign:string[]=['MF','MM','WF','WM','LGBT','D','Totals']

  items:string[]=
  [
    'Number of attorneys who serve on the highest governance committee of the firm',
    'Number of lawyers who lead offices',
    'Number of lawyers who lead Firm-wide practice groups or departments',
    'Number of lawyers who lead local office practice groups or departments',
    'Number of lawyers who lead firm-wide committees',
    'Number of attorneys on the Partner Review Committee or the equivalent',
    'Number of lawyers who serve on the firm-wide compensation committee',
    'Number of hiring partners or equivalent'
  ]
  myForm: FormGroup;
  constructor(private fb:FormBuilder) { }

  
  
  
  ngOnInit() {
    this.myForm = this.fb.group
    ({
      regions: this.fb.array([]),
      firmID:[1001,Validators.required]
    })
    this.addRow();
    this.myForm.valueChanges.subscribe(()=>{
      console.log('t')
      const control = <FormArray>this.myForm.controls['regions'];
      for(var i =0;i<control.length;i++){
        const demographics =<FormGroup> control.at(i);

        this.firmLeadassign.forEach(element => {
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
      'MF':[0,Validators.required],
      'MM': [0,Validators.required ],
      'WF': [0, Validators.required ],
      'WM': [0,Validators.required ],
      'LGBT': [0,Validators.required],
      'D': [0,Validators.required]
    });
  }

  sample(index:number){
    const control = <FormArray>this.myForm.controls['regions'];
    const formb=<FormGroup>control.at(index)
    // console.log((formb.controls['regions'].value))
    return (formb.controls['region'].value)
    // console.log(formbuild)
    // return formbuild.control['validate'].value
    //return control[index].controls['validate'].value
  }

  compute(index : number){
    const control = <FormArray>this.myForm.controls['regions'];
    const formb=<FormGroup>control.at(index)
    var value:number=0;
   
      this.firmLeadassign.forEach(element => {
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

      this.firmLead.forEach(element => {
        if(element!='Totals')
        console.log(element +' ' +demographics.controls[element].value)
      });
    }
  }
}