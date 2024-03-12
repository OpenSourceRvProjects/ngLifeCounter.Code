import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, interval } from 'rxjs';
import { EventService } from 'src/app/Services/Events/event.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

@Component({
  selector: 'app-my-counter',
  templateUrl: './my-counter.component.html',
  styleUrls: ['./my-counter.component.css']
})
export class MyCounterComponent {

  constructor(private localStorageService: LocalStorageService, 
    private router: Router, 
    private route: ActivatedRoute,
    private eventCounterService: EventService, @Inject('BASE_URL') private baseUrl : any){}
    id: string = "";
    isPublicCounter : boolean = false;
    private sub: any;

  uuid: string = "";
  viewYear : number = 0;
  viewMonth : number = 0;
  viewDay: number = 0;
  viewMinutes: number  = 0;
  viewHour : number = 0;
  viewSeconds: number = 0;

  eventName : string = "";
  dogURL : string = "";

   milliSecondsInASecond = 1000;
   hoursInADay = 24;
   minutesInAnHour = 60;
   SecondsInAMinute  = 60;
   isShared : boolean = false;

   isCountDown : boolean = false;

  _startDate : Date = new Date();
  private subscription?: Subscription;

  ngOnInit(){
    this.localStorageService.avtiveCounterView();
    this.getDoggie();
    this.sub = this.route.queryParams.subscribe(params=>{
      debugger;
      this.id = params['id'];
      this.isShared = params['shared']
      this.getEvent();
    });
  }

  getEvent(){
      this.eventCounterService.getEventByID(this.id)
      .subscribe({next: (data:any)=>{
        this._startDate = new Date(data.year, data.month - 1, data.day, data.hour, data.minutes, 0);
        this.eventName = data.name;
        this.uuid = data.counterID;
        this.isPublicCounter = data.isPublicCounter;
        this.putCounterTimeData();
        this.subscription = interval(1000)
        .subscribe(x => { this.putCounterTimeData(); });

      }, error : (err) => {
        this.router.navigate(['/counter/list'])
      }})
  }

  putCounterTimeData (){

    var timeDifference = (new Date().getTime()) - this._startDate.valueOf();

    this.viewSeconds = Math.floor((timeDifference) / (this.milliSecondsInASecond) % this.SecondsInAMinute);
    this.viewMinutes = Math.floor((timeDifference) / (this.milliSecondsInASecond * this.minutesInAnHour) % this.SecondsInAMinute);
    this.viewHour = Math.floor((timeDifference) / (this.milliSecondsInASecond * this.minutesInAnHour * this.SecondsInAMinute) % this.hoursInADay);
    this.viewDay = Math.floor((timeDifference) / (this.milliSecondsInASecond * this.minutesInAnHour * this.SecondsInAMinute * this.hoursInADay));
    this.isCountDown = false;

    if (this.viewSeconds < 0){
      this.isCountDown = true;
      this.eventName = this.eventName
      this.viewSeconds = (this.viewSeconds * -1) -1;
      this.viewMinutes = (this.viewMinutes * -1) - 1;
      this.viewHour = (this.viewHour * -1) - 1;
      this.viewDay = (this.viewDay * -1)  -1;
    }
  
  }

  

  goToListPage() {
    this.router.navigate(['/counter/list']);
  }

  getDoggie(){
    fetch('https://dog.ceo/api/breeds/image/random')
        .then(response => response.json())
        .then(data =>{
            this.dogURL = data.message;
        });
  }
}
