import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPrivacyComponent } from './user-privacy/user-privacy.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { RegisterRoutingModule } from './register-routing.module';
import { EnvironmentModule } from '../environment/environment.module';
import { ForgotPasswordComponent } from './password/forgot-password/forgot-password.component';



@NgModule({
  declarations: [
    RegisterComponent,
    UserPrivacyComponent,
    ForgotPasswordComponent
  ],
  imports: [
    RegisterRoutingModule,
    EnvironmentModule,
    FormsModule,
    CommonModule
  ]
})
export class RegisterModule { }
