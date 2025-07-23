import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ILoginModel } from 'src/app/Models/Account/ILoginModel';
import { AccountService } from 'src/app/Services/Accounts/account.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';
import { NavMenuComponent } from 'src/app/nav-menu/nav-menu.component';

declare const google: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  loginModel: ILoginModel = <ILoginModel>{ userName: "", password: "" };
  userName: string;
  password: string;
  errorMessage: string;
  processing: boolean = false;
  constructor(private router: Router, private accountService: AccountService, private localStorage: LocalStorageService) {
    this.userName = "";
    this.password = "";
    this.errorMessage = "";
  }

  ngOnInit() {

    this.accountService.getGoogleClientID().
      subscribe({
        next: (data: any) => {
          debugger;
          google.accounts.id.initialize({
            client_id: data.googleClientID,
            callback: this.handleGoogleCredentialResponse.bind(this)
          });

          google.accounts.id.renderButton(
            document.getElementById('google-signin-button'),
            { theme: 'outline', size: 'large' }
          );
        }
      })

    this.accountService.getMaintenancePage();

    if (this.localStorage.getUserData())
      this.router.navigate(['/'])
  }

  handleGoogleCredentialResponse(response: any) {
    debugger;
    this.errorMessage = "";
    this.processing = true;
    const credential = response.credential;
    this.accountService.googleLogin(credential).subscribe({
      next: (data) => {
        debugger;
        this.localStorage.saveUserData(data);
        this.processing = false;
        window.location.href = "/"

      }, error: (err) => {
        debugger;
        // alert("Error " + err.error)
        this.processing = false;
        alert("Hubo un problema al conectarte con tu cuenta de google!, quizá ya te encuentras registrado");
        window.location.href = "/login";
      }
    })
  }

  login() {

    if (this.loginModel.userName.trim() === '' || this.loginModel.password.trim() === '')
      this.errorMessage = "El usuario y contraseña son obligatorios";

    this.processing = true;
    this.accountService.login(this.loginModel)
      .subscribe({
        next: (data: any) => {
          debugger;
          if (data.token != null) {
            this.localStorage.saveUserData(data);
            this.processing = false;
            window.location.href = "/"
            // this.router.navigate(['/']);
          }
          else {
            this.errorMessage = "Contraseña no valida";
            this.processing = false;
          }
        }
        , error: (err) => {
          debugger;
          if (err.status == 429) {
            alert("Demasiados intentos, intentalo en unos momentos mas");
          }
          else
            alert("Error! Usuario no existe o fuera de servicio");

          this.processing = false;

        }
      })
  }
}
