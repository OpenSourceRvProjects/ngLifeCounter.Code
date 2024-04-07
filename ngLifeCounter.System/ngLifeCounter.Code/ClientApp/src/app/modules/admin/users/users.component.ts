import { Component } from '@angular/core';
import { IUsersModel } from 'src/app/Models/Account/IUsersModel';
import { AccountService } from 'src/app/Services/Accounts/account.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {

  constructor(private accountService : AccountService) {
  }

  users : IUsersModel[] = [];

  ngOnInit(){
    this.accountService.getAllUsers()
    .subscribe({next: (data: any)=> {
      this.users = data
    }, error: (err)=> {

    }})
  }
}
