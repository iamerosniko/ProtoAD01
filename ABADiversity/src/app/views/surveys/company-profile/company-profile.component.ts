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
  @Output() updateCertFormToParent = new EventEmitter<any>();
  @Input() companyProfileID:string;
  @Input() firmID:string;
  CPdata:CompanyProfiles={};
  myForm: FormGroup;
  certform: FormGroup;
  tempCertificate:Certificates={}
  tempCertificates:Certificates[]=[]

  
  constructor( private fb:FormBuilder) {   
  }

  ngOnInit() {
    this.myForm = this.fb.group({
      CompanyProfileID:[this.companyProfileID,Validators.required],
      FirmID:[this.companyProfileID,Validators.required],
      Firmname:[null, Validators.required],
      Firmhead:[null, Validators.required],
      Datecomp:[null, Validators.required],
      Srcname :[null, Validators.required],
      Srctitle:[null, Validators.required],
      Srcemail:[null, Validators.required],
      Totalfw:[0, Validators.required],
      Totalusfw:[0, Validators.required],
      Sizecat:[0, Validators.required],
      Firmown:[null, Validators.required],
      Catown:[null, Validators.required],
      Firmcert:[null, Validators.required],
    });

    this.certform = this.fb.group({
      certificates : [ 
        this.tempCertificates
      ]
    })

    this.myForm.valueChanges.subscribe(()=>{
      this.sendthistoparent();
    });
    this.sendthistoparent();
  }

  sendthistoparent(){
    this.updateChildFormToParent.emit(this.myForm)
    this.updateCertFormToParent.emit(this.certform)
  }
  addcert(cert:Certificates){
    cert.certificateID=UUID.UUID();
    cert.companyProfileID=this.companyProfileID;
    this.tempCertificates.push(cert);
    this.tempCertificate={};
    console.log(this.myForm.value)
  }
}
