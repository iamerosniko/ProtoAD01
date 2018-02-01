import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component';
import { SurveysModule } from './views/surveys/surveys.module';
import { ReportsModule } from './views/reports/reports.module';
import { OthersModule } from './views/others/others.module';
@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    SurveysModule,
    ReportsModule,
    OthersModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
