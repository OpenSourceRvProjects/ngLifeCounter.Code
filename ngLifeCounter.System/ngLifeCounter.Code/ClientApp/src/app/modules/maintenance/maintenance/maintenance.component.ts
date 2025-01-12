import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from '../../../Services/Storage/local-storage.service';

@Component({
  selector: 'app-maintenance',
  templateUrl: './maintenance.component.html',
  //styleUrls: ['./login.component.css']
})
export class MaintenanceComponent implements OnInit {

  constructor(private localStorageService: LocalStorageService) { }

  img: string = "assets/maintenancePageImg.jpeg"
  ngOnInit() {
    debugger;
    this.localStorageService.avtiveCounterView();
  }

}
