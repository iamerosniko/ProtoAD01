import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NoaccessComponent } from './noaccess/noaccess.component';
import { LoginComponent } from './login/login.component';
import { RedirectingComponent } from './redirecting/redirecting.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [NoaccessComponent, LoginComponent, RedirectingComponent]
})
export class OthersModule { }
