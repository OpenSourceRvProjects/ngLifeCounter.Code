import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LocalStorageService } from '../Storage/local-storage.service';
import { INewEventCounterModel } from 'src/app/Models/EventCounter/INewEventCounterModel';
import { ICounterPrivacySetModel } from 'src/app/Models/EventCounter/ICounterPrivacySetModel';
import { TextValueItem } from 'src/app/Models/TextValueItem';
import { ICounterDataModel } from 'src/app/Models/EventCounter/ICounterDataModel';

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

  getEventsResume(){
    var headers = this.initHeaders();
    return this.http.get(this.baseUrl +"api/EventCounter/getCountersResume", {headers})
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

  editEventCounter(eventID: string, isRelapse : boolean, eventCounter: ICounterDataModel ){
    var headers = this.initHeaders();
    var body = eventCounter;
    return this.http.put(this.baseUrl +"api/EventCounter/editCounterEvent?id=" + eventID + "&isRelapse=" + isRelapse, body, {headers})
  }



  getMonths(){
    var monthsList = [];
    monthsList.push(<TextValueItem>{number: 1, text : "Enero"})
    monthsList.push(<TextValueItem>{number: 2, text : "Febrero"})
    monthsList.push(<TextValueItem>{number: 3, text : "Marzo"})
    monthsList.push(<TextValueItem>{number: 4, text : "Abril"})
    monthsList.push(<TextValueItem>{number: 5, text : "Mayo"})
    monthsList.push(<TextValueItem>{number: 6, text : "Junio"})
    monthsList.push(<TextValueItem>{number: 7, text : "Julio"})
    monthsList.push(<TextValueItem>{number: 8, text : "Agosto"})
    monthsList.push(<TextValueItem>{number: 9, text : "Septiembre"})
    monthsList.push(<TextValueItem>{number: 10, text : "Octubre"})
    monthsList.push(<TextValueItem>{number: 11, text : "Noviembre"})
    monthsList.push(<TextValueItem>{number: 12, text : "Diciembre"})
    return monthsList;
  }

  getHours(){
    var hourList = [];
    hourList.push(<TextValueItem>{number: 0, text: "12:00 AM"})
    hourList.push(<TextValueItem>{number: 1, text: "01:00 AM"})
    hourList.push(<TextValueItem>{number: 2, text: "02:00 AM"})
    hourList.push(<TextValueItem>{number: 3, text: "03:00 AM"})
    hourList.push(<TextValueItem>{number: 4, text: "04:00 AM"})
    hourList.push(<TextValueItem>{number: 5, text: "05:00 AM"})
    hourList.push(<TextValueItem>{number: 6, text: "06:00 AM"})
    hourList.push(<TextValueItem>{number: 7, text: "07:00 AM"})
    hourList.push(<TextValueItem>{number: 8, text: "08:00 AM"})
    hourList.push(<TextValueItem>{number: 9, text: "09:00 AM"})
    hourList.push(<TextValueItem>{number: 10, text: "10:00 AM"})
    hourList.push(<TextValueItem>{number: 11, text: "11:00 AM"})
    hourList.push(<TextValueItem>{number: 12, text: "12:00 PM"})
    hourList.push(<TextValueItem>{number: 13, text: "01:00 PM"})
    hourList.push(<TextValueItem>{number: 14, text: "02:00 PM"})
    hourList.push(<TextValueItem>{number: 15, text: "03:00 PM"})
    hourList.push(<TextValueItem>{number: 16, text: "04:00 PM"})
    hourList.push(<TextValueItem>{number: 17, text: "05:00 PM"})
    hourList.push(<TextValueItem>{number: 18, text: "06:00 PM"})
    hourList.push(<TextValueItem>{number: 19, text: "07:00 PM"})
    hourList.push(<TextValueItem>{number: 20, text: "08:00 PM"})
    hourList.push(<TextValueItem>{number: 21, text: "09:00 PM"})
    hourList.push(<TextValueItem>{number: 22, text: "10:00 PM"})
    hourList.push(<TextValueItem>{number: 23, text: "11:00 PM"})

    return hourList;
  }

}
