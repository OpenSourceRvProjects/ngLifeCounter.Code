import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './modules/login/login/login.component';
import { RegisterComponent } from './modules/register/register/register.component';
// import { LoginComponent } from './Views/login/login.component';

const routes: Routes = [
//   {
//     // path: 'login',
//     // component: LoginComponent,
    
//   },
      { path: '', component: RegisterComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'register', component: RegisterComponent},
      { path: 'login', component: LoginComponent}
//   {
//     path: 'register',
//     component: RegisterComponent,
    
//   }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }