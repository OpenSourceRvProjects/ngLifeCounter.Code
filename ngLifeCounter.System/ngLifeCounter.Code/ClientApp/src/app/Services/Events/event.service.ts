import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LocalStorageService } from '../Storage/local-storage.service';
import { INewEventCounterModel } from 'src/app/Models/EventCounter/INewEventCounterModel';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private loclStorage: LocalStorageService) { }

  private initHeaders() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization' : 'Bearer ' + this.loclStorage.getUserData().token,
    })
    return headers;
  }


  addEvent(newEvent : INewEventCounterModel){
    debugger;
    var headers = this.initHeaders();
    return this.http.post(this.baseUrl + "api/EventCounter", newEvent, {headers})
  }

}
