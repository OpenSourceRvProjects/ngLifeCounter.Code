import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCounterComponent } from './add-counter/add-counter.component';
import { CounterListComponent } from './counter-list/counter-list.component';



@NgModule({
  declarations: [
    AddCounterComponent,
    CounterListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CounterModule { }
