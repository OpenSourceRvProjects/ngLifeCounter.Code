import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IRegisterModel } from 'src/app/Models/Account/IRegisterModel';
import { LocalStorageService } from '../Storage/local-storage.service';
import { ILoginModel } from 'src/app/Models/Account/ILoginModel';
import { IChangePasswordModel } from 'src/app/Models/Profile/IChangePasswordModel';
import { Router } from '@angular/router';

import * as msal from '@azure/msal-browser';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private msalInstance!: msal.PublicClientApplication;

  googleRegister(credential: any) {
    return this.http.post(this.baseUrl + 'api/Account/registerGoogleAuth', { idToken: credential });
  }

  googleLogin(credential: any) {
    return this.http.post(this.baseUrl + 'api/Account/loginGoogleAuth', { idToken: credential });
  }

  microsoftRegister(idToken: any) {
    return this.http.post(this.baseUrl + 'api/Account/registerMicrosoftAuth', { idToken: idToken });
  }

  microsofLogin(idToken: any) {
    return this.http.post(this.baseUrl + 'api/Account/loginMicrosoftAuth', { idToken: idToken });
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private localStorage: LocalStorageService, private router: Router) { }

  registerAccount(registerUser: IRegisterModel) {
    var body = registerUser;
    return this.http.post(this.baseUrl + "api/Account/signUp", body);
  }

  loginURL(userName: string, password: string) {
    return this.http.get(this.baseUrl + `api/Account/login?userName=${userName}&password=${password}`);
  }

  login(loginModel: ILoginModel) {
    return this.http.post(this.baseUrl + `api/Account/login`, loginModel);
  }

  changeMyPassword(loginModel: IChangePasswordModel) {
    return this.http.post(this.baseUrl + `api/Account/changePassword`, loginModel);
  }

  sendRecoveryEmail(email: string) {
    return this.http.get(this.baseUrl + `api/Account/resetPassword?email=${email}`);
  }

  changePassword(id: string, newPassword: string) {
    return this.http.get(this.baseUrl + `api/Account/changePasswordWithURL?id=${id}&password=${newPassword}`);

  }

  getAllUsers() {
    return this.http.get(this.baseUrl + `api/Admin/getAllUsers`);

  }

  validateChangePasswordURL(id: string) {
    return this.http.get(this.baseUrl + `api/Account/validateRecoveryRequestID?requestID=${id}`);
  }

  loginImpersonate(userID: string) {
    return this.http.get(this.baseUrl + `api/Account/impersonate?userID=${userID}`);
  }

  getGoogleClientID() {
    return this.http.get(this.baseUrl + `api/Account/getGoogleClientID`);
  }

  getMicrosoftClientID() {
    return this.http.get(this.baseUrl + `api/Account/getMicrosoftClientID`);
  }

  getMaintenancePage() {
    this.http.get(this.baseUrl + `api/Account/maintenancePage`).subscribe({
      next: (data: any) => {
        debugger;
        if (data.showMaintenancePage) {
          this.router.navigate(['/maintenancePage'])
        }
      }
    });
  }


  async initMicrosoftAuth(): Promise<void> {
    const response: any = await this.http.get(this.baseUrl + 'api/Account/getMicrosoftClientID').toPromise();

    this.msalInstance = new msal.PublicClientApplication({
      auth: {
        clientId: response.microsoftClientID,
        redirectUri: window.location.origin
      }
    });

    await this.msalInstance.initialize();
  }

  getMsalInstance(): msal.PublicClientApplication {
    if (!this.msalInstance) {
      throw new Error("MSAL instance not initialized. Call initMicrosoftAuth() first.");
    }
    return this.msalInstance;
  }



  blockMaintenancePageIfNotApplicable() {
    this.http.get(this.baseUrl + `api/Account/maintenancePage`).subscribe({
      next: (data: any) => {
        debugger;
        if (!data.showMaintenancePage) {
          this.router.navigate(['/'])
        }
      }
    });
  }
}
