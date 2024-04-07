import { Component } from '@angular/core';
import { EventService } from 'src/app/Services/Events/event.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

interface IResume {
  eventsCount : number;
  relapsesCount : number;
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {


  username?: string;

  constructor(private localStorage: LocalStorageService, private eventService : EventService ) {
  }

  countersResume: IResume = <IResume> { eventsCount : 0, relapsesCount: 0}

  ngOnInit(){
    this.localStorage.desactivateCounterView();
    this.username = "";
    this.username = this.localStorage.getUserData().userName;
    this.eventService.getEventsResume()
    .subscribe({next: (data: any)=>{
      this.countersResume = data;
    }, error: (err)=> {

    }})
  }
}
