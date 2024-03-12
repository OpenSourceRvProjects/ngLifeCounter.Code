import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { AppModule } from 'src/app/app.module';
import { EnvironmentModule } from '../environment/environment.module';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';



@NgModule({
    
  declarations: [
    LoginComponent,

  ],
  imports: [
    CommonModule,
    FormsModule,
    LoginRoutingModule,
    EnvironmentModule
    
    ],
    exports: [],
    providers: []

})
export class LoginModule { }
