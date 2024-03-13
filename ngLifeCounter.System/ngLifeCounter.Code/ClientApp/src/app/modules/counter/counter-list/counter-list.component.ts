import { Component } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
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


  constructor(private modalService: NgbModal, private eventService: EventService, private localStorageService: LocalStorageService) {
  }

  counterList : IEventCounterItemModel[] = [];
  counterSetting : ICounterPrivacySetModel = <ICounterPrivacySetModel>{}; 
  closeResult = '';
  selectedCounterEdit : IEventCounterItemModel = <IEventCounterItemModel>{};

  ngOnInit(){
    this.localStorageService.desactivateCounterView();
    this.getCountersList();
  }

  editSelectedCounter(){
    this.modalService.dismissAll();
  }
  
	open(content : any, counterEvent : IEventCounterItemModel) {

    this.selectedCounterEdit = counterEvent;
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

  getCountersList(){
    this.eventService.getEvents()
    .subscribe({next: (data : any)=> {
      this.counterList =  data;
      
    }, 
    error : (err)=> {

    }})
  }
}
