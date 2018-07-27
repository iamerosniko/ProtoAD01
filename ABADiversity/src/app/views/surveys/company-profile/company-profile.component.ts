import { Component, OnInit,Output,EventEmitter,Input  } from '@angular/core';
// import { CPEntities,Certificates } from '../entities/companyProfile';
import { Certificates, CompanyProfiles } from '../../../entities/entities';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UUID } from 'angular2-uuid'
@Component({
  selector: 'app-company-profile',
  templateUrl: './company-profile.component.html',
  styleUrls: ['./company-profile.component.css']
})
export class CompanyProfileComponent implements OnInit {
  @Output() updateChildFormToParent = new EventEmitter<any>();
  @Input() companyProfileID:string;
  CPdata:CompanyProfiles={};
  myForm: FormGroup;
  certform: FormGroup;
  tempCertificate:Certificates={}
  tempCertificates:Certificates[]=[]

  
  constructor( private fb:FormBuilder) {   
  }

  ngOnInit() {
    this.myForm = this.fb.group({
      compantProfileID:[this.companyProfileID,Validators.required],
      firmname:[null, Validators.required],
      firmhead:[null, Validators.required],
      datecomp:[null, Validators.required],
      srcname :[null, Validators.required],
      srctitle:[null, Validators.required],
      srcemail:[null, Validators.required],
      totalfw:[null, Validators.required],
      totalusfw:[null, Validators.required],
      sizecat:[null, Validators.required],
      firmown:[null, Validators.required],
      catown:[null, Validators.required],
      firmcert:[null, Validators.required],
      certificate:[this.certform = this.fb.group({
        certificates : [ 
          this.tempCertificates
        ]
      })]
    });
    this.myForm.valueChanges.subscribe(()=>{
      this.sendthistoparent();
    });
    this.sendthistoparent();
  }

  sendthistoparent(){
    this.updateChildFormToParent.emit(this.myForm)
  }
  addcert(cert:Certificates){
    cert.certificateID=UUID.UUID();
    this.tempCertificates.push(cert);
    this.tempCertificate={};
    console.log(this.myForm.value)
  }
}
