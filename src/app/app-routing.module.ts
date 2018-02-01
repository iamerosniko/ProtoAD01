import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReportsComponent } from './views/reports/reports.component';
import { SurveysComponent } from './views/surveys/surveys.component';

import { NoaccessComponent } from './views/others/noaccess/noaccess.component';
import { LoginComponent } from './views/others/login/login.component';
import { LogoutComponent } from './views/others/logout/logout.component';

import { AuthGuard } from './router.services/auth-guard.services';
const routes: Routes = [
  { path: '', redirectTo:'/Login', pathMatch:"full" },
  { path: 'Reports', component : ReportsComponent, canActivate:[AuthGuard] },
  { path: 'Survey', component : SurveysComponent, canActivate:[AuthGuard] },
  { path: 'Logout', component:LogoutComponent},
  { path: 'Login', component:LoginComponent},
  { path: 'Noaccess', component:NoaccessComponent},
  { path: '**', redirectTo :'/Login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash:true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
