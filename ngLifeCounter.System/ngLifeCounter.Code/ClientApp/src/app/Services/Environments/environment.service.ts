import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAppEnvironment(){
    return this.http.get(this.baseUrl + "api/Environment");
  }
}
