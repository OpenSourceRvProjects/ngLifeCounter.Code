import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPrivacyComponent } from './user-privacy/user-privacy.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { RegisterRoutingModule } from './register-routing.module';
import { EnvironmentModule } from '../environment/environment.module';



@NgModule({
  declarations: [
    RegisterComponent,
    UserPrivacyComponent
  ],
  imports: [
    RegisterRoutingModule,
    EnvironmentModule,
    FormsModule,
    CommonModule
  ]
})
export class RegisterModule { }
