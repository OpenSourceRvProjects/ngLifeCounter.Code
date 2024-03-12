import { Component } from '@angular/core';
import { LocalStorageService } from '../Services/Storage/local-storage.service';

@Component({
  selector: 'app-environment-information',
  templateUrl: './environment-information.component.html',
  styleUrls: ['./environment-information.component.css']
})
export class EnvironmentInformationComponent {

/**
 *
 */
constructor(private localStorageService: LocalStorageService) {
  
}

  ngOnInit(){
    // this.localStorageService.desactivateCounterView();
  }

}
