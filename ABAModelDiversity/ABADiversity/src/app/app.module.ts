import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component';
import { OthersModule } from './views/others/others.module';
import { AuthGuard } from './auth-guard.services';

import { FormsModule }    from '@angular/forms';

import { HttpModule } from '@angular/http'
import { ClientApiService,ClientApiSettings, ClientLoginService } from './services/client.services';
import { EnvironmentSvc } from './services/environments.service';
import { TopNavComponent } from './views/main/top-nav/top-nav.component';

@NgModule({
  declarations: [
    AppComponent,
    TopNavComponent,
  ],
  imports: [
    HttpModule,
    FormsModule,
    BrowserModule,
    OthersModule,
    AppRoutingModule,
  ],
  providers: [AuthGuard, ClientApiService, ClientApiSettings, ClientLoginService, EnvironmentSvc],
  bootstrap: [AppComponent]
})
export class AppModule { }
