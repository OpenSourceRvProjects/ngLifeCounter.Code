import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCounterComponent } from './add-counter/add-counter.component';
import { CounterListComponent } from './counter-list/counter-list.component';
import { CounterRoutingModule } from './counter-routing.module';
import { FormsModule } from '@angular/forms';
import { MyCounterComponent } from './my-counter/my-counter.component';

@NgModule({
  declarations: [
    AddCounterComponent,
    CounterListComponent,
    MyCounterComponent
  ],
  imports: [
    CounterRoutingModule,
    FormsModule,
    CommonModule
  ]
})
export class CounterModule { }
