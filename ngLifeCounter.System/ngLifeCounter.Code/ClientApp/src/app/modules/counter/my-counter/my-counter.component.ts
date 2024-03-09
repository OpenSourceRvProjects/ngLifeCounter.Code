import { Component } from '@angular/core';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

@Component({
  selector: 'app-my-counter',
  templateUrl: './my-counter.component.html',
  styleUrls: ['./my-counter.component.css']
})
export class MyCounterComponent {

  constructor(private localStorageService: LocalStorageService){}

  ngOninit(){
    this.localStorageService.avtiveCounterView();
  }

}
