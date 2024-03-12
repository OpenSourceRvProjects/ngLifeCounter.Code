import { Component } from '@angular/core';
import { EnvironmentService } from 'src/app/Services/Environments/environment.service';

@Component({
  selector: 'app-environment-banner',
  templateUrl: './environment-banner.component.html',
  styleUrls: ['./environment-banner.component.css']
})
export class EnvironmentBannerComponent {

  
  showBannerQA : boolean = false;
  showBannerDEV : boolean = false;
  constructor(private environmentService : EnvironmentService){ }

  ngOnInit(){
    this.environmentService.getAppEnvironment().
    subscribe({next: (data: any) =>{
      debugger;
      if (data.environmentName == 'QA')
        this.showBannerQA = true;
      if (data.environmentName == 'DEV')
        this.showBannerDEV = true;
    }, error: (err) =>{

    } });
  }



}
