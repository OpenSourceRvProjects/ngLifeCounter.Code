import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddCounterComponent } from "./add-counter/add-counter.component";
import { UserGuard } from "src/app/Security/user.guard";


const routes: Routes = [
  { path: 'counter/add', component: AddCounterComponent, canActivate: [UserGuard], data: {name : "Agregar evento", showInNavBar : true}}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })

export class CounterRoutingModule {
  static getRoutes(): Routes {
    return routes;
  }

 }