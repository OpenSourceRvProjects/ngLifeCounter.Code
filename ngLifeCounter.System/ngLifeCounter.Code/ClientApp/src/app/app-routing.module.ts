import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RegisterComponent } from './Pages/register/register.component';
// import { LoginComponent } from './Views/login/login.component';

const routes: Routes = [
//   {
//     // path: 'login',
//     // component: LoginComponent,
    
//   },
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      {path: 'register', component: RegisterComponent}
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