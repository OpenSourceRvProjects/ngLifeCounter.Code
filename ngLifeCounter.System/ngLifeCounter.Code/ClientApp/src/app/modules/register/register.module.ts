import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPrivacyComponent } from './user-privacy/user-privacy.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from '../login/login/login.component';
import { FormsModule } from '@angular/forms';
import { RegisterRoutingModule } from './register-routing.module';



@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent,
    UserPrivacyComponent
  ],
  imports: [
    RegisterRoutingModule,
    FormsModule,
    CommonModule
  ]
})
export class RegisterModule { }
