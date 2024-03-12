import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EnvironmentBannerComponent } from './environment-banner/environment-banner.component';

@NgModule({
  declarations: [
    EnvironmentBannerComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [EnvironmentBannerComponent],
  providers: []
})
export class EnvironmentModule { }
