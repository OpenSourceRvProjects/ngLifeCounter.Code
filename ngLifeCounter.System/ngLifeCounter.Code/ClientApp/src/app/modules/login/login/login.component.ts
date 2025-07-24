import { Component, NgZone, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ILoginModel } from 'src/app/Models/Account/ILoginModel';
import { AccountService } from 'src/app/Services/Accounts/account.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';
import { NavMenuComponent } from 'src/app/nav-menu/nav-menu.component';

declare const google: any;
import * as msal from '@azure/msal-browser';

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
  isEnableProviderLogin = false;
  private msalInstance!: msal.PublicClientApplication;
  constructor(private router: Router, private accountService: AccountService, private localStorage: LocalStorageService, private ngZone: NgZone) {
    this.userName = "";
    this.password = "";
    this.errorMessage = "";
  }

  async ngOnInit() {
    this.accountService.getMaintenancePage();

    this.accountService.getGoogleClientID().
      subscribe({
        next: (data: any) => {
          debugger;
          google.accounts.id.initialize({
            client_id: data.googleClientID,
            callback: this.handleGoogleCredentialResponse.bind(this)
          });

          //google.accounts.id.renderButton(
          //  document.getElementById('google-signin-button'),
          //  { theme: 'outline', size: 'large' }
          //);
        }
      })


    this.msalInstance = new msal.PublicClientApplication({
      auth: {
        clientId: 'bf7b7993-314e-411a-a67d-4da49366c464',
        redirectUri: window.location.origin
      }
    });
    // ⬅️ Required in MSAL v3+
    await this.msalInstance.initialize();
    
    if (this.localStorage.getUserData())
      this.router.navigate(['/'])
  }

  handleGoogleCredentialResponse(response: any) {

    this.ngZone.run(() => {
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
          this.errorMessage = "Hubo un problema al conectarte con tu cuenta de google!, Probablemente aún no te registras con tu cuenta de google";
          //window.location.href = "/login";
        }
      });
    });
  }


  enableProviderLogin() {
    this.isEnableProviderLogin = true;


    const button = document.createElement("button");
    button.innerText = "Regístrate con Outlook";
    button.classList.add("btn", "btn-outline-primary", "w-100");
    button.onclick = () => this.loginWithMicrosoft();


    setTimeout(() => {
      google.accounts.id.renderButton(
        document.getElementById('google-signin-button'),
        { theme: 'outline', size: 'large' }
      );
    });
  }


  loginWithMicrosoft() {
    this.processing = true;
    this.errorMessage = "";

    this.msalInstance.loginPopup({
      scopes: ["openid", "email", "profile"],
    }).then((response: any) => {
      const idToken = response.idToken;

      this.accountService.microsofLogin(idToken).subscribe({
        next: (data: any) => {
          debugger;
          this.localStorage.saveUserData(data);
          this.processing = false;
          window.location.href = "/"
        },
        error: () => {
          this.processing = false;
          this.errorMessage = "Error con el inicio de sesión de Microsoft. Quizá ya estás registrado.";
        }
      });
    }).catch((error: any) => {
      this.processing = false;
      this.errorMessage = "Error al conectar con Microsoft";
      console.error(error);
    });
  }


  triggerGoogleLogin() {
    google.accounts.id.prompt(); // Show the Google One Tap or popup
  }

  //triggerGoogleLogin() {
  //  google.accounts.id.prompt((notification: any) => {
  //    if (notification.isNotDisplayed() || notification.isSkippedMoment()) {
  //      console.log('Google Sign-In prompt was skipped or not displayed.');
  //    }
  //  });
  //}

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
