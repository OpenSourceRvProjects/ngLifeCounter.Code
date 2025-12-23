import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CopyLinkComponent } from './copy-link/copy-link.component';
import { RewardCoinComponent } from './reward-coin/reward-coin.component';
import { FormLogoComponent } from './form-logo/form-logo.component';
import { ContavidaAppComponent } from './contavida-banner/contavida-app.component';



@NgModule({
  declarations: [
    CopyLinkComponent,
    RewardCoinComponent,
    FormLogoComponent,
    ContavidaAppComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
  ],
  exports: [CopyLinkComponent, RewardCoinComponent, FormLogoComponent, ContavidaAppComponent]
})
export class SharedModule { }
