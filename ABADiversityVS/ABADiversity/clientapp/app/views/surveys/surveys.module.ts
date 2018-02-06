import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SurveysComponent } from './surveys.component';
import { SideNavComponent } from '../side-nav/side-nav.component';
import { SaveBarComponent } from '../save-bar/save-bar.component';
import { CompanyProfileComponent } from '../company-profile/company-profile.component';
import { FirmDemographicsComponent } from '../firm-demographics/firm-demographics.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [SurveysComponent,SideNavComponent,SaveBarComponent,CompanyProfileComponent,FirmDemographicsComponent]
})
export class SurveysModule { }
