import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddCounterComponent } from "./add-counter/add-counter.component";
import { UserGuard } from "src/app/Security/user.guard";
import { CounterListComponent } from "./counter-list/counter-list.component";
import { MyCounterComponent } from "./my-counter/my-counter.component";


const routes: Routes = [
  { path: 'counter/add', component: AddCounterComponent, canActivate: [UserGuard], data: {name : "Agregar evento", showInNavBar : true}},
  { path: 'counter/list', component: CounterListComponent, canActivate: [UserGuard], data: {name : "Tus eventos/contadores", showInNavBar : true}},
  { path: 'counter/myCounter', component: MyCounterComponent},

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