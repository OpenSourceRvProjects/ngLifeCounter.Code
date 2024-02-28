import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { RegisterComponent } from "./register/register.component";
import { UserPrivacyComponent } from "./user-privacy/user-privacy.component";

const routes: Routes = [

    { path: 'register', component: RegisterComponent, data: {name : "Registro"}},
    { path: 'privacy', component: UserPrivacyComponent, data: {name : "Privacidad"}},
]

@NgModule({
    //this is just the same as  this.router.config.push({ path: 'register', component: RegisterComponent})
    imports: [RouterModule.forRoot(routes)],
    exports : [RouterModule]
})

export class RegisterRoutingModule{ 

    static getRoutes() {
        return routes;
      }
}