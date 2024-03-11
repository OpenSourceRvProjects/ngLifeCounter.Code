import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EnvironmentInformationComponent } from './environment-information/environment-information.component';
// import { LoginComponent } from './Views/login/login.component';

const routes: Routes = [
  { path: 'environmentInfo', component: EnvironmentInformationComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }