import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReportsComponent } from './views/reports/reports.component';
import { SurveysComponent } from './views/surveys/surveys.component';

import { NoaccessComponent } from './views/others/noaccess/noaccess.component';
import { LoginComponent } from './views/others/login/login.component';
import { LogoutComponent } from './views/others/logout/logout.component';
import { RedirectingComponent } from './views/others/redirecting/redirecting.component';

import { AuthGuard } from './auth-guard.services';
const routes: Routes = [
  // { path: '', redirectTo:'/Survey', pathMatch:"full" },
  // { path: 'Reports', component : ReportsComponent },
  // { path: 'Survey', component : SurveysComponent},
 

  { path: '', redirectTo:'/Survey', pathMatch:"full" },
  { path: 'Login', component:LoginComponent},
  { path: 'Redirecting', component : RedirectingComponent},
  { path: 'Logout', component:LogoutComponent},
  { path: 'Noaccess', component:NoaccessComponent},
  { path: '**', redirectTo :'/Survey' },
  { path: 'Survey', component : SurveysComponent},
  { path: 'Reports', component : ReportsComponent, canActivate:[AuthGuard] },

  { path: '**', redirectTo :'/Survey' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash:true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
