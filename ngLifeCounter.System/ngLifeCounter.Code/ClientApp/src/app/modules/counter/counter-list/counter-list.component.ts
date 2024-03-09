import { Component } from '@angular/core';
import { IEventCounterItemModel } from 'src/app/Models/EventCounter/IEventCounterItemModel';
import { EventService } from 'src/app/Services/Events/event.service';

@Component({
  selector: 'app-counter-list',
  templateUrl: './counter-list.component.html',
  styleUrls: ['./counter-list.component.css']
})
export class CounterListComponent {


  constructor(private eventService: EventService) {
  }

  counterList : IEventCounterItemModel[] = [];

  ngOnInit(){
    this.getCountersList();
  }

  getCountersList(){
    this.eventService.getEvents()
    .subscribe({next: (data : any)=> {
      this.counterList =  data;
      
    }, 
    error : (err)=> {

    }})
  }
}
