import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LocalStorageService } from '../Storage/local-storage.service';
import { INewEventCounterModel } from 'src/app/Models/EventCounter/INewEventCounterModel';
import { ICounterPrivacySetModel } from 'src/app/Models/EventCounter/ICounterPrivacySetModel';

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

  getEvents(){
    var headers = this.initHeaders();
    return this.http.get(this.baseUrl +"api/EventCounter", {headers})
  }

  getEventByID(eventID: string){

    if (this.loclStorage.getUserData()) {
      var headers = this.initHeaders();
      return this.http.get(this.baseUrl + "api/EventCounter/getById?counterID=" + eventID, {headers})
    }
    else{
      return this.http.get(this.baseUrl + "api/EventCounter/getById?counterID=" + eventID)

    }
  }

  changeEventPrivacySetting(eventID: string, setting: ICounterPrivacySetModel ){
    var headers = this.initHeaders();
    var body = setting;
    return this.http.put(this.baseUrl +"api/EventCounter/changeCounterPrivacy?id=" + eventID, body, {headers})
  }

}
