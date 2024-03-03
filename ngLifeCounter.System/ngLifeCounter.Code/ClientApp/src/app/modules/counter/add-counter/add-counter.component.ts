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
  processing : boolean = false;
  errorMessage: string = "";

  constructor(private eventCounterService: EventService, private router: Router){}


  addEvent(){
    debugger;

    if (this.newCounterEvent.eventName == undefined || this.newCounterEvent.eventName.trim() == ''){
      this.errorMessage = "El nombre de tu evento sirve de identificador, ingrésalo";
      return;
    }

    if (this.newCounterEvent.year == undefined || this.newCounterEvent.year <= 1900 || this.newCounterEvent.year > 3900){
      this.errorMessage = "Año inválido, ingresa un año mayor a 1900 y menor a 3900";
      return;
    }

    if (this.newCounterEvent.month == undefined || this.newCounterEvent.month <= 0 || this.newCounterEvent.month > 12){
      this.errorMessage = "Mes inválido";
      return;
    }

    
    if (this.newCounterEvent.day == undefined || this.newCounterEvent.day <= 0 || this.newCounterEvent.day > 31){
      this.errorMessage = "Día inválido";
      return;
    }

    if (this.newCounterEvent.hour == undefined || this.newCounterEvent.hour < 0 || this.newCounterEvent.hour > 24){
      this.errorMessage = "Hora inválida";
      return;
    }

    if (this.newCounterEvent.minutes == undefined || this.newCounterEvent.minutes < 0 || this.newCounterEvent.minutes > 60){
      this.errorMessage = "Minutos inválidos";
      return;
    }


    this.processing = true;
    this.eventCounterService.addEvent(this.newCounterEvent)
    .subscribe({next: ()=>{
      this.processing = false;
      this.router.navigate(["/"]);
    }, error: (err) => {
      this.processing = false;
      alert("Error!!!");
    }})
  }

}
