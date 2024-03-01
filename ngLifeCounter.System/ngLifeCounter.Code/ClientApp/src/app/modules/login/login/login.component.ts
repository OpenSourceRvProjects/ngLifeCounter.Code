import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/Services/Accounts/account.service';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userName : string;
  password: string;
  errorMessage : string;
  processing : boolean =  false;
  constructor(private router: Router, private accountService: AccountService, private localStorage : LocalStorageService) {
    this.userName = "";
    this.password = "";
    this.errorMessage = "";
  }

  ngOnInit() {
    debugger;
    if (this.localStorage.getUserData())
      this.router.navigate(['/'])
  }

  login(){
    this.processing = true;
    this.accountService.login(this.userName, this.password)
    .subscribe({next: (data: any)=>{
      debugger;
      if (data.token.trim() !== ''){
        this.localStorage.saveUserData(data);
        this.processing = false;
        this.router.navigate(['/']);
      }
      else
        {
          this.errorMessage = "Contraseña no valida";
          this.processing = false;  
        }
      }
    , error: (err)=>{

    }})
  }
}
