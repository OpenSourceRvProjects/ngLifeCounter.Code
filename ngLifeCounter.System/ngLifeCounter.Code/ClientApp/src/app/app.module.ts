import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { RegisterModule } from './modules/register/register.module';
import { LoginModule } from './modules/login/login.module';
import { HomeRoutingModule } from './modules/home/home-routing.module';
import { CounterModule } from './modules/counter/counter.module';
import { EnvironmentModule } from './modules/environment/environment.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    EnvironmentModule,
    HttpClientModule,
    HomeRoutingModule,
    AppRoutingModule,
    CounterModule,
    LoginModule,
    RegisterModule,

  ],
  exports: [],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
