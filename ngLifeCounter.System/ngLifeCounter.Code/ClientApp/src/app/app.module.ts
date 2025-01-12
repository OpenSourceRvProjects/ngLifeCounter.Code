import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { RegisterModule } from './modules/register/register.module';
import { LoginModule } from './modules/login/login.module';
import { HomeRoutingModule } from './modules/home/home-routing.module';
import { CounterModule } from './modules/counter/counter.module';
import { EnvironmentModule } from './modules/environment/environment.module';
import { SharedModule } from './modules/shared/shared.module';
import { ProfileModule } from './modules/profile/profile.module';
import { AdminModule } from './modules/admin/admin.module';
import { AuthInterceptorService } from './Services/AuthInterceptorService';
import { HomeModule } from './modules/home/home.module';
import { MaintenanceModule } from './modules/maintenance/maintenance.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    EnvironmentModule,
    SharedModule,
    HttpClientModule,
    HomeRoutingModule,
    AppRoutingModule,
    HomeModule,
    CounterModule,
    ProfileModule,
    LoginModule,
    RegisterModule,
    AdminModule,
    MaintenanceModule

  ],
  exports: [],
  providers: [
    {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptorService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
