import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CopyLinkComponent } from './copy-link/copy-link.component';
import { RewardCoinComponent } from './reward-coin/reward-coin.component';



@NgModule({
  declarations: [
    CopyLinkComponent,
    RewardCoinComponent
  ],
  imports: [
    FormsModule,
    CommonModule
  ],
  exports: [CopyLinkComponent, RewardCoinComponent]
})
export class SharedModule { }
