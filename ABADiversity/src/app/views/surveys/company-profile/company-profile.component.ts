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
  CPdata:CompanyProfiles={};
  myForm: FormGroup;
  certform: FormGroup;
  tempCertificate:Certificates={}
  tempCertificates:Certificates[]=[]

  
  constructor( private fb:FormBuilder) {
    this.myForm = this.fb.group({
      firmname:[this.CPdata.firmname, Validators.required],
      firmhead:[this.CPdata.firmhead, Validators.required],
      datecomp:[this.CPdata.datecomp, Validators.required],
      srcname :[this.CPdata.srcname, Validators.required],
      srctitle:[this.CPdata.srctitle, Validators.required],
      srcemail:[this.CPdata.srcemail, Validators.required],
      totalfw:[this.CPdata.totalfw, Validators.required],
      totalusfw:[this.CPdata.totalusfw, Validators.required],
      sizecat:[this.CPdata.sizecat, Validators.required],
      firmown:[this.CPdata.firmown, Validators.required],
      catown:[this.CPdata.catown, Validators.required],
      firmcert:[this.CPdata.firmcert, Validators.required],
      certificate:[this.certform = this.fb.group({
        certificates : [ 
          this.tempCertificates
        ]
      })]
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
  addcert(cert:Certificates){
    cert.certificateID=UUID.UUID();
    this.tempCertificates.push(cert);
    this.tempCertificate={};
    console.log(this.myForm.value)
  }
}
