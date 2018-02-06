import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SurveysComponent } from './surveys.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { SaveBarComponent } from './save-bar/save-bar.component';
import { CompanyProfileComponent } from './company-profile/company-profile.component';
import { FirmDemographicsComponent } from './firm-demographics/firm-demographics.component';
import { FirmLeadershipDemographicComponent } from './firm-leadership-demographic/firm-leadership-demographic.component';
import { LawyersLeftComponent } from './lawyers-left/lawyers-left.component';
import { LawyersJoinedComponent } from './lawyers-joined/lawyers-joined.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [SurveysComponent,SideNavComponent,SaveBarComponent,CompanyProfileComponent,FirmDemographicsComponent, FirmLeadershipDemographicComponent, LawyersLeftComponent, LawyersJoinedComponent]
})
export class SurveysModule { }
