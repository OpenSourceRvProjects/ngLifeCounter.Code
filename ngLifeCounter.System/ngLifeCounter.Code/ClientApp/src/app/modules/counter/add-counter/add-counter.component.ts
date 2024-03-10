import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IRegisterModel } from 'src/app/Models/Account/IRegisterModel';
import { INewEventCounterModel } from 'src/app/Models/EventCounter/INewEventCounterModel';
import { EventService } from 'src/app/Services/Events/event.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

interface TextValueItem {
  number : number;
  text : string;
}

@Component({
  selector: 'app-add-counter',
  templateUrl: './add-counter.component.html',
  styleUrls: ['./add-counter.component.css']
})
export class AddCounterComponent {

  newCounterEvent : INewEventCounterModel = <INewEventCounterModel>{};
  processing : boolean = false;
  errorMessage: string = "";

  selectedMonth : TextValueItem = <TextValueItem>{};
  monthsList : TextValueItem [] = [];

  selectedHour : TextValueItem = <TextValueItem>{};
  hourList : TextValueItem [] = [];

  constructor(private eventCounterService: EventService, private router: Router, private localStorageService: LocalStorageService){}

  ngOnInit(){
    this.localStorageService.desactivateCounterView();
    this.populateMonths();
    this.pupulateHours();
  }

  populateMonths() {
    this.monthsList.push(<TextValueItem>{number: 1, text : "Enero"})
    this.monthsList.push(<TextValueItem>{number: 2, text : "Febrero"})
    this.monthsList.push(<TextValueItem>{number: 3, text : "Marzo"})
    this.monthsList.push(<TextValueItem>{number: 4, text : "Abril"})
    this.monthsList.push(<TextValueItem>{number: 5, text : "Mayo"})
    this.monthsList.push(<TextValueItem>{number: 6, text : "Junio"})
    this.monthsList.push(<TextValueItem>{number: 7, text : "Julio"})
    this.monthsList.push(<TextValueItem>{number: 8, text : "Agosto"})
    this.monthsList.push(<TextValueItem>{number: 9, text : "Septiembre"})
    this.monthsList.push(<TextValueItem>{number: 10, text : "Octubre"})
    this.monthsList.push(<TextValueItem>{number: 11, text : "Noviembre"})
    this.monthsList.push(<TextValueItem>{number: 12, text : "Diciembre"})
    this.selectedMonth = this.monthsList[0];
    this.newCounterEvent.day = 1;
  }

  pupulateHours(){
    this.hourList.push(<TextValueItem>{number: 0, text: "12:00 AM"})
    this.hourList.push(<TextValueItem>{number: 1, text: "01:00 AM"})
    this.hourList.push(<TextValueItem>{number: 2, text: "02:00 AM"})
    this.hourList.push(<TextValueItem>{number: 3, text: "03:00 AM"})
    this.hourList.push(<TextValueItem>{number: 4, text: "04:00 AM"})
    this.hourList.push(<TextValueItem>{number: 5, text: "05:00 AM"})
    this.hourList.push(<TextValueItem>{number: 6, text: "06:00 AM"})
    this.hourList.push(<TextValueItem>{number: 7, text: "07:00 AM"})
    this.hourList.push(<TextValueItem>{number: 8, text: "08:00 AM"})
    this.hourList.push(<TextValueItem>{number: 9, text: "09:00 AM"})
    this.hourList.push(<TextValueItem>{number: 10, text: "10:00 AM"})
    this.hourList.push(<TextValueItem>{number: 11, text: "11:00 AM"})
    this.hourList.push(<TextValueItem>{number: 12, text: "12:00 PM"})
    this.hourList.push(<TextValueItem>{number: 13, text: "01:00 PM"})
    this.hourList.push(<TextValueItem>{number: 14, text: "02:00 PM"})
    this.hourList.push(<TextValueItem>{number: 15, text: "03:00 PM"})
    this.hourList.push(<TextValueItem>{number: 16, text: "04:00 PM"})
    this.hourList.push(<TextValueItem>{number: 17, text: "05:00 PM"})
    this.hourList.push(<TextValueItem>{number: 18, text: "06:00 PM"})
    this.hourList.push(<TextValueItem>{number: 19, text: "07:00 PM"})
    this.hourList.push(<TextValueItem>{number: 20, text: "08:00 PM"})
    this.hourList.push(<TextValueItem>{number: 21, text: "09:00 PM"})
    this.hourList.push(<TextValueItem>{number: 22, text: "10:00 PM"})
    this.hourList.push(<TextValueItem>{number: 23, text: "11:00 PM"})
    this.selectedHour = this.hourList[0];
    this.newCounterEvent.minutes = 0;

  }

  addEvent(){
    this.newCounterEvent.month = this.selectedMonth.number;
    this.newCounterEvent.hour = this.selectedHour.number;

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
