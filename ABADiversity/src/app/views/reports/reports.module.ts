import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChartsModule } from 'ng2-charts'
import { FormsModule } from '@angular/forms';

import { ReportsComponent } from './reports.component';
import { RacePositionComponent } from './race-position/race-position.component';
import { PositionRaceComponent } from './position-race/position-race.component';
@NgModule({
  imports: [
    CommonModule,
    ChartsModule,
    FormsModule
  ],
  declarations: [ReportsComponent, RacePositionComponent, PositionRaceComponent]
})
export class ReportsModule { }
