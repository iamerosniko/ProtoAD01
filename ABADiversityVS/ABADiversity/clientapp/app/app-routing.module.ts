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
  { path: '', redirectTo:'/Survey', pathMatch:"full" },
  { path: 'Reports', component : ReportsComponent },
  { path: 'Survey', component : SurveysComponent},
  { path: 'Redirecting', component : RedirectingComponent},
  { path: 'Logout', component:LogoutComponent},
  { path: 'Login', component:LoginComponent},
  { path: 'Noaccess', component:NoaccessComponent},
  { path: '**', redirectTo :'/Survey' }
  // { path: '', redirectTo:'/Login', pathMatch:"full" },
  // { path: '**', redirectTo :'/Login' }
  // { path: 'Survey', component : SurveysComponent, canActivate:[AuthGuard] },
  // { path: 'Reports', component : ReportsComponent, canActivate:[AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash:true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
