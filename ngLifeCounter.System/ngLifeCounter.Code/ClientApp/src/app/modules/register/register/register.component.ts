import { Component, OnInit } from '@angular/core';
import { IRegisterModel } from 'src/app/Models/Account/IRegisterModel';
import { AccountService } from 'src/app/Services/Accounts/account.service';

declare const google: any;
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerModel : IRegisterModel = <IRegisterModel>{};
  passwordConfirmation? : string;
  errorMessage? : string;
  processing? : boolean;
  isFinishRegister? : boolean;

  constructor(private accountService: AccountService) {
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
    this.passwordConfirmation = "";
    this.errorMessage = "";
    this.processing = false;
    this.isFinishRegister =  false;
  }



  handleGoogleCredentialResponse(response: any) {
    debugger;
    this.errorMessage = "";
    this.processing = true;
    const credential = response.credential;
    this.accountService.googleRegister(credential).subscribe({
      next: (data) => {
        debugger;
        this.processing = false;
        this.isFinishRegister = true;
        this.goToLoginPage();

      }, error: (err) => {
        debugger;
        // alert("Error " + err.error)
        this.processing = false;
        alert("Hubo un problema al conectarte con tu cuenta de google!, quizá ya te encuentras registrado");
        window.location.href = "/register";
      }
    })
    //this.http.post(this.baseUrl + 'api/GoogleAuth', { idToken: credential }).subscribe(result => {
    //  console.log("User authenticated via Google!", result);
    //}, error => {
    //  console.error("Google login failed", error);
    //});
  }


  registerAccount() {
    debugger;
    this.errorMessage = "";

    if (this.registerModel.name == undefined || this.registerModel.name === "" || this.registerModel.name.trim() === ""){
      this.errorMessage = "Necesitamos tu nombre para crear tu cuenta";
      return;
    }

    if (this.registerModel.lastName1 == undefined || this.registerModel.name === "" || this.registerModel.name.trim() === ""){
      this.errorMessage = "Necesitamos alguno de tus apellidos para crear tu cuenta";
      return;
    }

    if (this.registerModel.lastName1 == undefined || this.registerModel.name === "" || this.registerModel.name.trim() === ""){
      this.errorMessage = "Necesitamos alguno de tus apellidos para crear tu cuenta";
      return;
    }

    if (this.registerModel.password == undefined || this.registerModel.password === "" || this.registerModel.name.trim() === ""){
      this.errorMessage = "Crea una contraseña para ti";
      return;
    }


    if (this.registerModel.password !== this.passwordConfirmation){
      this.errorMessage = "Ups!, la contraseña que ingresaste no coincide con la confirmación";
      return;
    }

    if (this.registerModel.password.length < 3){
      this.errorMessage = "Tu contraseña es super insegura! ingresa una con más caracteres";
      return;
    }

    if (this.registerModel.userName.length < 3){
      this.errorMessage = "Tu nombre de usuario es tu identidad, se creativo!";
      return;
    }

    if (this.checkWhitespace(this.registerModel.userName))
    {
      this.errorMessage = "Tu nombre de usuario no puede contener espacios en blanco";
      return;
    }

    if (this.checkWhitespace(this.registerModel.password))
    {
      this.errorMessage = "No es recomendable que tu contraseña tenga espacios en blanco";
      return;
    }
    
    if (!this.validateEmail(this.registerModel.email)){
      this.errorMessage = "El correo no tiene formato válido";
      return;
    }

    //error 400 if I not send this value
    this.registerModel.lastName2 = ".";
    this.processing = true;
    this.accountService.registerAccount(this.registerModel).subscribe({next : (data)=>{
      this.processing = false;  
      this.isFinishRegister = true;

    }, error : (err)=> {
      debugger;
      // alert("Error " + err.error)
      this.processing = false;
      this.errorMessage = err.error
    }})
  }


  validateEmail(email : string) {
    return String(email)
      .toLowerCase()
      .match(
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      );
  };

   checkWhitespace(str : string) { 
    let whitespace = new Set([" ", "\t", "\n"]); 
    for (let i = 0; i < str.length; i++) { 
        if (whitespace.has(str[i])) { 
            return true; 
        } 
    } 
    return false; 
} 

  goToLoginPage(){
    window.location.href = "/login";
  }
  
}
