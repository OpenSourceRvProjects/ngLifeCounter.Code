import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCounterComponent } from './add-counter/add-counter.component';
import { CounterListComponent } from './counter-list/counter-list.component';
import { CounterRoutingModule } from './counter-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AddCounterComponent,
    CounterListComponent
  ],
  imports: [
    CounterRoutingModule,
    FormsModule,
    CommonModule
  ]
})
export class CounterModule { }
