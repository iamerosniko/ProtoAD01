import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartsModule } from 'ng2-charts'

import { ReportsComponent } from './reports.component';
@NgModule({
  imports: [
    CommonModule,
    ChartsModule
  ],
  declarations: [ReportsComponent]
})
export class ReportsModule { }
