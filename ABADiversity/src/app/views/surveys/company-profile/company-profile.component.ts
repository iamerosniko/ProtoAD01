import { Component, OnInit,Output,EventEmitter,Input,OnChanges  } from '@angular/core';
// import { CPEntities,Certificates } from '../entities/companyProfile';
import { Certificates, CompanyProfiles } from '../../../entities/entities';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UUID } from 'angular2-uuid'
import { SurveyService } from '../../../services/survey.service'
@Component({
  selector: 'app-company-profile',
  templateUrl: './company-profile.component.html',
  styleUrls: ['./company-profile.component.css']
})
export class CompanyProfileComponent implements OnInit,OnChanges {
  @Output() updateChildFormToParent = new EventEmitter<any>();
  @Output() updateCertFormToParent = new EventEmitter<any>();
  @Input() companyProfileID:string;
  @Input() firmID:string;

  CPdata:CompanyProfiles={};
  myForm: FormGroup;
  certform: FormGroup;
  tempCertificate:Certificates={}
  tempCertificates:Certificates[]=[]
  isExisting:boolean=false;
  
  constructor(private surveySvc:SurveyService, private fb:FormBuilder) {   
  }

  ngOnChanges(){
    this.getValue();

    console.log('company profile')
  }

  ngOnInit() {
    this.initializeForm();
  }

  async getValue(){
    var companyProfile = await this.surveySvc.getSurvey(this.companyProfileID,1);
    var tempCertificates = await this.surveySvc.getSurvey(this.companyProfileID,10)
    this.tempCertificates=tempCertificates ? tempCertificates : [];
    this.isExisting = companyProfile ? true : false ;
    this.CPdata = companyProfile ? companyProfile : {};
    console.log(this.CPdata )
    console.log(this.tempCertificates )
    this.initializeForm();
  }

  sendthistoparent(){
    this.updateChildFormToParent.emit(this.myForm)
    this.updateCertFormToParent.emit(this.certform)
  }
  addcert(cert:Certificates){
    console.log(cert);
    console.log(this.tempCertificate)
    console.log(this.tempCertificates)
    cert.certificateID=UUID.UUID();
    cert.companyProfileID=this.companyProfileID;
    this.tempCertificates.push(this.tempCertificate);
    this.tempCertificate={};
    console.log(this.myForm.value)
  }

  initializeForm(){
    this.myForm = this.fb.group({
      CompanyProfileID:[this.companyProfileID,Validators.required],
      FirmID:[this.firmID,Validators.required],
      Firmname:[this.CPdata.firmname, Validators.required],
      Firmhead:[this.CPdata.firmhead, Validators.required],
      Datecomp:[null, Validators.required],
      Srcname :[this.CPdata.srcname, Validators.required],
      Srctitle:[this.CPdata.srctitle, Validators.required],
      Srcemail:[this.CPdata.srcemail, Validators.required],
      Totalfw:[this.CPdata.totalfw, Validators.required],
      Totalusfw:[this.CPdata.totalusfw, Validators.required],
      Sizecat:[this.CPdata.sizecat, Validators.required],
      Firmown:[this.CPdata.firmown, Validators.required],
      Catown:[this.CPdata.catown, Validators.required],
      Firmcert:[this.CPdata.firmcert, Validators.required],
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
}
