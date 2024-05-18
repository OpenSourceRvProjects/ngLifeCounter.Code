import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PasswordChangeComponent } from '../password-change/password-change.component';

@Component({
  selector: 'app-personal-profile',
  templateUrl: './personal-profile.component.html',
  styleUrls: ['./personal-profile.component.css']
})
export class PersonalProfileComponent {


  constructor(private modalService: NgbModal, public router: Router) {
    
  }


  openChangePassword(){
    const modalRef = this.modalService.open(PasswordChangeComponent, {ariaLabelledBy: 'modal-basic-title', size: 'lg' });
  }
}
