import { Component, OnInit, Input } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IEventCounterItemModel } from 'src/app/Models/EventCounter/IEventCounterItemModel';
import { RelapsesDataModel } from 'src/app/Models/Relapses/IRelapseDetailModel';
import { EventService } from 'src/app/Services/Events/event.service';
import { RelapsesService } from 'src/app/Services/Relapses/relapses.service';
@Component({
  selector: 'relapses-modal',
  templateUrl: './modalDeleteCounter.html',
  styleUrls: ['./modalDeleteCounter.css']
})
export class ModalDeleteCounterComponent implements OnInit {
 

  @Input() counterEventToDelete: IEventCounterItemModel = <IEventCounterItemModel>{};

  processing: boolean = false;
  relapsesData: RelapsesDataModel = <RelapsesDataModel>{};
  uiTokenDelete: string = "";
  userTokenUi: string = "";

  constructor(public activeModal: NgbActiveModal, private eventService: EventService) { }
    ngOnInit(): void {
        debugger;
    this.uiTokenDelete = this.makeid(5);

  }

    makeid(length : number) {
    let result = '';
    const characters = 'ABCDEFGHIJKLMNPQRSTUVWXYZ123456789';
    const charactersLength = characters.length;

    for (var counter = 0; counter < 5; counter++){
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
    }


}