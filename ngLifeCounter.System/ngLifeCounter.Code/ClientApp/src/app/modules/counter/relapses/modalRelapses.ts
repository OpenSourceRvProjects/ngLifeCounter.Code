import { Component, OnInit, Input } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IEventCounterItemModel } from 'src/app/Models/EventCounter/IEventCounterItemModel';
import { RelapsesDataModel } from 'src/app/Models/Relapses/IRelapseDetailModel';
import { EventService } from 'src/app/Services/Events/event.service';
import { RelapsesService } from 'src/app/Services/Relapses/relapses.service';
@Component({
  selector: 'relapses-modal',
  templateUrl: './modalRelapses.html',
  styleUrls: ['./goldCoin.css', './plateCoin.css']
})
export class ModalRelapsesComponent implements OnInit {

  @Input() counterEvent: IEventCounterItemModel = <IEventCounterItemModel>{};
  constructor(public activeModal: NgbActiveModal, private relapseService: RelapsesService) { }

  processing: boolean = false;
  relapsesData: RelapsesDataModel = <RelapsesDataModel>{};

  ngOnInit() {
    this.relapseService.getRelapses(this.counterEvent.id)
    .subscribe({next: (data : any) =>{
        this.relapsesData = data;
    }, error: (err)=>{

    }})

  }

}