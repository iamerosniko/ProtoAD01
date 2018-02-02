import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component';
import { SurveysModule } from './views/surveys/surveys.module';
import { ReportsModule } from './views/reports/reports.module';
import { OthersModule } from './views/others/others.module';
import { AuthGuard } from './router.services/auth-guard.services';
import { HttpModule } from '@angular/http'
import { ClientApiService,ClientApiSettings,LoginService } from './services/aba.services';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    HttpModule,
    BrowserModule,
    SurveysModule,
    ReportsModule,
    OthersModule,
    AppRoutingModule
  ],
  providers: [AuthGuard,ClientApiService,ClientApiSettings,LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
