import { Component, OnInit, Input } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ICounterDataModel } from 'src/app/Models/EventCounter/ICounterDataModel';
import { IEventCounterItemModel } from 'src/app/Models/EventCounter/IEventCounterItemModel';
import { TextValueItem } from 'src/app/Models/TextValueItem';
import { EventService } from 'src/app/Services/Events/event.service';
@Component({
  selector: 'edit-modal',
  templateUrl: './modalEditCounter.html',
//   styleUrls: ['./modal.component.css']
})
export class ModalEditComponent implements OnInit {

  @Input() counterEvent: IEventCounterItemModel = <IEventCounterItemModel>{};
  processing: boolean = false;
  selectedDetailedCounter : ICounterDataModel = <ICounterDataModel>{};
  selectedCounterToEdit : IEventCounterItemModel = <IEventCounterItemModel>{};
  selectedHourToDetailedCounter : TextValueItem = <TextValueItem>{};
  selectedMonthToDetailCounter : TextValueItem = <TextValueItem>{};
  hoursForEditMode : TextValueItem[] = [];
  monthsForEditMode : TextValueItem[] = [];
  isRelapse : boolean =  false;
  constructor(public activeModal: NgbActiveModal, private eventService: EventService) { }

  ngOnInit() {
    this.hoursForEditMode = this.eventService.getHours();
    this.monthsForEditMode =  this.eventService.getMonths();
    this.selectedCounterToEdit = this.counterEvent;

    this.eventService.getEventByID(this.selectedCounterToEdit.id)
    .subscribe({next : (data : any)=> {
      debugger;
      this.selectedDetailedCounter = data;
      this.selectedHourToDetailedCounter = this.hoursForEditMode.find(f=> f.number == this.selectedDetailedCounter.hour)!;
      this.selectedMonthToDetailCounter = this.monthsForEditMode.find(f=> f.number == this.selectedDetailedCounter.month)!;
    }, error: (error)=>{
      alert("Evento no encontrado")
    }})

  }

  editSelectedCounter(){
    this.processing = true;
    this.selectedDetailedCounter.hour = this.selectedHourToDetailedCounter.number;
    this.selectedDetailedCounter.month = this.selectedMonthToDetailCounter.number;

    this.eventService.editEventCounter(this.selectedDetailedCounter.counterID, this.isRelapse, this.selectedDetailedCounter)
    .subscribe({next: (data)=>{
      debugger;
      this.activeModal.close();
      this.processing = false;
      this.isRelapse =  false;
      window.location.href = "/counter/list"
    //   this.getCountersList();

    }, error: (err)=>{
      this.processing = false;
      alert("No se pudo actualizar la información, verifica que la hora y fecha sea correcta");
    }},)

  }
  

}