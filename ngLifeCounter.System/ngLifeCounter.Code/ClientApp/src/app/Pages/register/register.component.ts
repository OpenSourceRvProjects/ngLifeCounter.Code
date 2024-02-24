import { Component, OnInit } from '@angular/core';
import { IRegisterModel } from 'src/app/Models/Account/IRegisterModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerModel : IRegisterModel = <IRegisterModel>{};
  passwordConfirmation? : string;
  errorMessage? : string;

  constructor() {
  }

  ngOnInit(){
    this.passwordConfirmation = "";
    this.errorMessage = "";
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


    alert(this.registerModel.name);
  }
}
