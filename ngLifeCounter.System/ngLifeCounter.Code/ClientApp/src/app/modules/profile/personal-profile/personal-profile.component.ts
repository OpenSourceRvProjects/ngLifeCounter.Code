import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-personal-profile',
  templateUrl: './personal-profile.component.html',
  styleUrls: ['./personal-profile.component.css']
})
export class PersonalProfileComponent {

  constructor(public router: Router) {
    
  }
}
