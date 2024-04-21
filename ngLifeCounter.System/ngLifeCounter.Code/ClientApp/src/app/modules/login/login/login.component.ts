import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ILoginModel } from 'src/app/Models/Account/ILoginModel';
import { AccountService } from 'src/app/Services/Accounts/account.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';
import { NavMenuComponent } from 'src/app/nav-menu/nav-menu.component';

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
    debugger;
    if (this.localStorage.getUserData())
      this.router.navigate(['/'])
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
