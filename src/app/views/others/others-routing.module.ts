import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NoaccessComponent } from './noaccess/noaccess.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';

const routes: Routes = [
  { path:'Logout', component:LogoutComponent},
  { path:'Login', component:LoginComponent},
  { path:'Noaccess', component:NoaccessComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OthersRoutingModule { }
