import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CopyLinkComponent } from './copy-link/copy-link.component';



@NgModule({
  declarations: [
    CopyLinkComponent
  ],
  imports: [
    FormsModule,
    CommonModule
  ],
  exports: [CopyLinkComponent]
})
export class SharedModule { }
