import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { LocalStorageService } from '../Storage/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class RelapsesService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private localStorage : LocalStorageService) { }

  getRelapses(eventCounterID : string){
    return this.http.get("api/Relapses/getEventCounterRelapses?eventCounterId=" + eventCounterID)
  }

}
