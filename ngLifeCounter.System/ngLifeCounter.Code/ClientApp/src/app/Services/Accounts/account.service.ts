import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IRegisterModel } from 'src/app/Models/Account/IRegisterModel';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  registerAccount(registerUser : IRegisterModel){
    debugger;
    var body = registerUser;
    return this.http.post(this.baseUrl + "api/Account/signUp", body );
  }

  login (userName: string, password: string ){
    return this.http.get(this.baseUrl + `api/Account/login?userName=${userName}&password=${password}`);
  }

}
