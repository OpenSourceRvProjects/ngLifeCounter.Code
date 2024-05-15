import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { LocalStorageService } from '../Storage/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class RelapsesService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private localStorage : LocalStorageService) { }

  private initHeaders() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization' : 'Bearer ' + this.localStorage.getUserData().token,
    })
    return headers;
  }

  getRelapses(eventCounterID : string){
    var headers = this.initHeaders();
    return this.http.get("api/Relapses/getEventCounterRelapses?eventCounterId=" + eventCounterID, {headers})
  }

}
