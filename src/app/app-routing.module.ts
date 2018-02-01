import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReportsComponent } from './views/reports/reports.component';
import { SurveysComponent } from './views/surveys/surveys.component';

  
const routes: Routes = [
  { path: '', redirectTo:'/Login', pathMatch:"full"},
  { path: 'Reports', component : ReportsComponent },
  { path: 'Survey', component : SurveysComponent },
  { path: '**', redirectTo :'/Login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash:true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
