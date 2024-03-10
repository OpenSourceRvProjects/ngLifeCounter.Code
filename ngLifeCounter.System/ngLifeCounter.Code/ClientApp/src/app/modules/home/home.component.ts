import { Component } from '@angular/core';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {


  username?: string;

  constructor(private localStorage: LocalStorageService) {
  }

  
  ngOnInit(){
    this.localStorage.desactivateCounterView();
    this.username = "";
    this.username = this.localStorage.getUserData().userName;
  }
}
