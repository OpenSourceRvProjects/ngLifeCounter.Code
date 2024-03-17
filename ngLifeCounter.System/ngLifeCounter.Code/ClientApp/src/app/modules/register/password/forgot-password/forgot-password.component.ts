import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/Services/Accounts/account.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {

  constructor(private route : ActivatedRoute, private accountService : AccountService){}

  email : string ="";
  private sub: any;
  id: string = "";

  sendEmailProcessing : boolean = false;
  emailSended : boolean = false;

  changePasswordProcesing : boolean = false;
  passwordChanged : boolean = false;
  hasID : boolean =  false;
  passwordConfirmation: string = "";
  password: string = "";

  ngOnInit(){
    this.sub = this.route.queryParams.subscribe(params=>{
      debugger;
      this.id = params['id'];
      if (this.id !== undefined)
        this.hasID = true;
    });
  }
  
  sendRecoveryEmail(){
    this.sendEmailProcessing = true;
    this.accountService.sendRecoveryEmail(this.email)
    .subscribe({next: (data: any)=>{
      this.sendEmailProcessing = false;
      this.emailSended = true;

      this.email = "";
    }, error: (err)=>{
      alert("No se pudo enviar el correo");
       this.sendEmailProcessing = false;
      
    }})
  }

  changePassword() {

    if (this.password.trim() == ""){
      alert("Tu contraseña no puede estar en blanco");
      return;
    }

    if (this.password !== this.passwordConfirmation){
      alert("La contraseña de confirmación no concuerda");
      return;
    }

    this.changePasswordProcesing =  true;
    this.accountService.changePassword(this.id, this.password)
    .subscribe({next: (data: any)=> {
      if (data == true){
        this.passwordChanged = true;
        this.changePasswordProcesing =  false;
        this.password = "";
        this.passwordConfirmation = "";
      }
      else
        alert("Ésta liga ha caducado o ya fue utilizada");
        this.password = "";
        this.passwordConfirmation = "";
        this.changePasswordProcesing =  false;

    }, error: (err)=> {
      alert ("Error en el servidor!");

    }});

  }
}
