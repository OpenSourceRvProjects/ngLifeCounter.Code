import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IRegisterModel } from 'src/app/Models/Account/IRegisterModel';
import { INewEventCounterModel } from 'src/app/Models/EventCounter/INewEventCounterModel';
import { EventService } from 'src/app/Services/Events/event.service';


@Component({
  selector: 'app-add-counter',
  templateUrl: './add-counter.component.html',
  styleUrls: ['./add-counter.component.css']
})
export class AddCounterComponent {

  newCounterEvent : INewEventCounterModel = <INewEventCounterModel>{};

  constructor(private eventCounterService: EventService, private router: Router){}


  addEvent(){
    this.eventCounterService.addEvent(this.newCounterEvent)
    .subscribe({next: ()=>{
      debugger;
      this.router.navigate(["/"]);
    }, error: (err) => {
      debugger;
      alert("Error!!!");
    }})
  }

}
