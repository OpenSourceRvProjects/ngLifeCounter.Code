import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICounterPrivacySetModel } from 'src/app/Models/EventCounter/ICounterPrivacySetModel';
import { IEventCounterItemModel } from 'src/app/Models/EventCounter/IEventCounterItemModel';
import { EventService } from 'src/app/Services/Events/event.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';
import { ModalEditComponent } from '../edit-counter/modalEditCounter';
import { ModalRelapsesComponent } from '../relapses/modalRelapses';
import { ModalDeleteCounterComponent } from '../delete-counter/modalDeleteCounter';

@Component({
  selector: 'app-counter-list',
  templateUrl: './counter-list.component.html',
  styleUrls: ['./counter-list.component.css']
})
export class CounterListComponent {
  constructor(private modalService: NgbModal, private eventService: EventService, 
    private localStorageService: LocalStorageService, public router : Router) {
  }

  counterList : IEventCounterItemModel[] = [];
  filteredCounterList : IEventCounterItemModel[] = [];
  counterSetting : ICounterPrivacySetModel = <ICounterPrivacySetModel>{}; 
  processing =  false;
  searchText: string = "";

  ngOnInit(){
    this.localStorageService.desactivateCounterView();
    this.getCountersList();
  }

  openEditPopUp(counterEvent : IEventCounterItemModel){
    const modalRef = this.modalService.open(ModalEditComponent, {ariaLabelledBy: 'modal-basic-title', size: 'lg' });
    modalRef.componentInstance.counterEvent = counterEvent;
  }

  openRelapsesPopUp(counterEvent : IEventCounterItemModel){
    const modalRef = this.modalService.open(ModalRelapsesComponent, {ariaLabelledBy: 'modal-basic-title', size: 'lg' });
    modalRef.componentInstance.counterEvent = counterEvent;
  }

  openDeletePopUp(counterEvent : IEventCounterItemModel){
    const modalRef = this.modalService.open(ModalDeleteCounterComponent, {ariaLabelledBy: 'modal-basic-title', size: 'lg' });
    modalRef.componentInstance.counterEventToDelete = counterEvent;
  }

  checkboxChange(eventItem: IEventCounterItemModel){
    this.counterSetting.isPublicCounter = eventItem.isPublic;

    this.eventService.changeEventPrivacySetting(eventItem.id, this.counterSetting)
    .subscribe({next: ()=> {
      this.counterSetting = <ICounterPrivacySetModel>{}
    }, error : (err) =>{

    }})
  }

  searchKey(data: string){
    this.searchText = data;

    if (this.searchText == '')
      this.filteredCounterList = this.counterList;
    else
      this.filteredCounterList = this.counterList.filter(f=> f.eventName.includes(this.searchText))
  }

  getCountersList(){
    this.eventService.getEvents()
    .subscribe({next: (data : any)=> {
      this.counterList =  data;
      this.filteredCounterList = data
    }, 
    error : (err)=> {

    }})
  }
}
