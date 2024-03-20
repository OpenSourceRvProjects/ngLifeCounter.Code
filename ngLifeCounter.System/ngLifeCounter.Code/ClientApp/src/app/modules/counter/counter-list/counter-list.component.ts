import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICounterDataModel } from 'src/app/Models/EventCounter/ICounterDataModel';
import { ICounterPrivacySetModel } from 'src/app/Models/EventCounter/ICounterPrivacySetModel';
import { IEventCounterItemModel } from 'src/app/Models/EventCounter/IEventCounterItemModel';
import { TextValueItem } from 'src/app/Models/TextValueItem';
import { EventService } from 'src/app/Services/Events/event.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

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
  closeResult = '';
  selectedCounterToEdit : IEventCounterItemModel = <IEventCounterItemModel>{};
  selectedDetailedCounter : ICounterDataModel = <ICounterDataModel>{};
  selectedHourToDetailedCounter : TextValueItem = <TextValueItem>{};
  selectedMonthToDetailCounter : TextValueItem = <TextValueItem>{};
  processing =  false;
  searchText: string = "";

  hoursForEditMode : TextValueItem[] = [];
  monthsForEditMode : TextValueItem[] = [];
  isRelapse : boolean =  false;
  ngOnInit(){
    this.localStorageService.desactivateCounterView();
    this.getCountersList();
    this.hoursForEditMode = this.eventService.getHours();
    this.monthsForEditMode =  this.eventService.getMonths();
  }

  editSelectedCounter(){
    this.processing = true;
    this.selectedDetailedCounter.hour = this.selectedHourToDetailedCounter.number;
    this.selectedDetailedCounter.month = this.selectedMonthToDetailCounter.number;

    this.eventService.editEventCounter(this.selectedDetailedCounter.counterID, this.isRelapse, this.selectedDetailedCounter)
    .subscribe({next: (data)=>{
      debugger;
      this.modalService.dismissAll();
      this.processing = false;
      this.isRelapse =  false;
      this.getCountersList();

    }, error: (err)=>{
      this.processing = false;
      alert("No se pudo actualizar la información, verifica que la hora y fecha sea correcta");
    }},)

  }
  
	open(content : any, counterEvent : IEventCounterItemModel) {
    this.selectedCounterToEdit = counterEvent;

    this.eventService.getEventByID(this.selectedCounterToEdit.id)
    .subscribe({next : (data : any)=> {
      this.selectedDetailedCounter = data;
      this.selectedHourToDetailedCounter = this.hoursForEditMode.find(f=> f.number == this.selectedDetailedCounter.hour)!;
      this.selectedMonthToDetailCounter = this.monthsForEditMode.find(f=> f.number == this.selectedDetailedCounter.month)!;
    }, error: (error)=>{
      alert("Evento no encontrado")
    }})

		this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'lg' }).result.then(
			(result) => {
				this.closeResult = `Closed with: ${result}`;
			},
			(reason) => {
				this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
			},
		);
	}

  private getDismissReason(reason: any): string {
		if (reason === ModalDismissReasons.ESC) {
			return 'by pressing ESC';
		} else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
			return 'by clicking on a backdrop';
		} else {
			return `with: ${reason}`;
		}
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
