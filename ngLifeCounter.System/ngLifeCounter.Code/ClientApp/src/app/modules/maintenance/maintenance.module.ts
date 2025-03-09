import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppModule } from 'src/app/app.module';
import { EnvironmentModule } from '../environment/environment.module';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { MaintenanceComponent } from './maintenance/maintenance.component';
import { MaintenanceRoutingModule } from './maintenance-routing.module';



@NgModule({

  declarations: [
    MaintenanceComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MaintenanceRoutingModule,
    SharedModule,

  ],
  exports: [],
  providers: []

})
export class MaintenanceModule { }
