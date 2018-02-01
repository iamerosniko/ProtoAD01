import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OthersRoutingModule } from './others-routing.module';
import { NoaccessComponent } from './noaccess/noaccess.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';

@NgModule({
  imports: [
    CommonModule,
    OthersRoutingModule
  ],
  declarations: [NoaccessComponent, LoginComponent, LogoutComponent]
})
export class OthersModule { }
