import { Component, OnInit, Input } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IChangePasswordModel } from 'src/app/Models/Profile/IChangePasswordModel';
import { AccountService } from 'src/app/Services/Accounts/account.service';

@Component({
  selector: 'app-password-change',
  templateUrl: './password-change.component.html',
  styleUrls: ['./password-change.component.css']
})
export class PasswordChangeComponent {

  processing: boolean = false;
  passwordChangeModel : IChangePasswordModel = <IChangePasswordModel>{
    oldPassword : "",
    newPassword : "",
  };

  passwordConfirm : string  ="";

  constructor(public activeModal: NgbActiveModal, public acountService: AccountService) { }
  
  changePassword () {
    // this.passwordChangeModel.changePassword = function(){
    // }
    // this.passwordChangeModel.changePassword();
    debugger;
    if (this.passwordConfirm !== this.passwordChangeModel.newPassword){
      alert("La confirmación de tu nuevo password no coincide, intentalo de nuevo");
      return;
    }

    this.acountService.changeMyPassword(this.passwordChangeModel)
    .subscribe({next: ()=>{
      window.location.href = "/";
    }, error: (err)=>{
      debugger;
      alert("Error :" + err.error.message);
    }});

  }

}