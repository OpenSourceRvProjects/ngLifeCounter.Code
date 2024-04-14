import { Component } from '@angular/core';
import { IUsersModel } from 'src/app/Models/Account/IUsersModel';
import { AccountService } from 'src/app/Services/Accounts/account.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {

  constructor(private accountService : AccountService, private localStorageService : LocalStorageService) {
  }

  users : IUsersModel[] = [];

  ngOnInit(){
    this.accountService.getAllUsers()
    .subscribe({next: (data: any)=> {
      this.users = data
    }, error: (err)=> {
    }})
  }

  impersonate(userID: string){
    this.accountService.loginImpersonate(userID)
    .subscribe({next: (data: any)=>{
      var response = data;
      this.localStorageService.swapToLoginImpersonate(response);
      window.location.href = "/";
      
    }})
  }
}
