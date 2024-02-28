import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userName? : string;
  password?: string;
  errorMessage? : string;
  constructor() {
  }

  ngOnInit() {
    this.userName = "";
    this.password = "";
    this.errorMessage = "";
  }

  login(){

  }
}
