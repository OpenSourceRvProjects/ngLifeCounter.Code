import { Component, OnInit } from '@angular/core';
import { IRegisterModel } from 'src/app/Models/Account/IRegisterModel';
import { AccountService } from 'src/app/Services/Accounts/account.service';

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

  constructor(private accountService: AccountService) {
  }

  ngOnInit(){
    this.passwordConfirmation = "";
    this.errorMessage = "";
    this.processing = false;
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

    //error 400 if I not send this value
    this.registerModel.lastName2 = ".";

    this.accountService.registerAccount(this.registerModel).subscribe({next : (data)=>{
        alert("Usuario guardado satisfactoriamente");

    }, error : (err)=> {
      debugger;
      alert("Error " + err)
    }})
  }
}
