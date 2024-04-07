import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IRegisterModel } from 'src/app/Models/Account/IRegisterModel';
import { LocalStorageService } from '../Storage/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private localStorage: LocalStorageService) { }

  
  private initHeaders() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization' : 'Bearer ' + this.localStorage.getUserData().token,
    })
    return headers;
  }


  registerAccount(registerUser : IRegisterModel){
    var body = registerUser;
    return this.http.post(this.baseUrl + "api/Account/signUp", body );
  }

  login (userName: string, password: string ){
    return this.http.get(this.baseUrl + `api/Account/login?userName=${userName}&password=${password}`);
  }

  sendRecoveryEmail (email: string ){
    return this.http.get(this.baseUrl + `api/Account/resetPassword?email=${email}`);
  }

  changePassword(id: string, newPassword : string){
    return this.http.get(this.baseUrl + `api/Account/changePasswordWithURL?id=${id}&password=${newPassword}`);

  }

  getAllUsers(){
    var headers = this.initHeaders();
    return this.http.get(this.baseUrl + `api/Admin/getAllUsers`, {headers});

  }

  validateChangePasswordURL(id: string)
  {
    return this.http.get(this.baseUrl + `api/Account/validateRecoveryRequestID?requestID=${id}`);
  }
}
