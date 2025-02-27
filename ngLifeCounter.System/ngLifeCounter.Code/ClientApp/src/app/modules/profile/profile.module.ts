import { NgModule } from "@angular/core";
import { PersonalProfileComponent } from './personal-profile/personal-profile.component';
import { ProfileRoutingModule } from "./profile-routing.module";
import { PasswordChangeComponent } from './password-change/password-change.component';
import { ImageCollectionComponent } from './image-collection/image-collection.component';
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "../shared/shared.module";


@NgModule({
  declarations: [
    PersonalProfileComponent,
    PasswordChangeComponent,
    ImageCollectionComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ProfileRoutingModule,
    NgbModule,
    SharedModule,
  ]
})
export class ProfileModule { }
