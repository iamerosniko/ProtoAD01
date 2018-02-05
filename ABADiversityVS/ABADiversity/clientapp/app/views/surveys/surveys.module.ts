import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SurveysComponent } from './surveys.component';
import { SideNavComponent } from '../side-nav/side-nav.component';
@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [SurveysComponent,SideNavComponent]
})
export class SurveysModule { }
