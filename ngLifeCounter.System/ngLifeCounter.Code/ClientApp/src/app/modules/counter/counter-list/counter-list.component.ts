import { Component } from '@angular/core';
import { ICounterPrivacySetModel } from 'src/app/Models/EventCounter/ICounterPrivacySetModel';
import { IEventCounterItemModel } from 'src/app/Models/EventCounter/IEventCounterItemModel';
import { EventService } from 'src/app/Services/Events/event.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

@Component({
  selector: 'app-counter-list',
  templateUrl: './counter-list.component.html',
  styleUrls: ['./counter-list.component.css']
})
export class CounterListComponent {


  constructor(private eventService: EventService, private localStorageService: LocalStorageService) {
  }

  counterList : IEventCounterItemModel[] = [];
  counterSetting : ICounterPrivacySetModel = <ICounterPrivacySetModel>{}; 

  ngOnInit(){
    this.localStorageService.desactivateCounterView();
    this.getCountersList();
  }

  checkboxChange(eventItem: IEventCounterItemModel){
    debugger;
    this.counterSetting.isPublicCounter = eventItem.isPublic;

    this.eventService.changeEventPrivacySetting(eventItem.id, this.counterSetting)
    .subscribe({next: ()=> {
      this.counterSetting = <ICounterPrivacySetModel>{}
    }, error : (err) =>{

    }})
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
