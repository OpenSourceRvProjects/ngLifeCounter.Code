import { Component, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from '../Services/Storage/local-storage.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  @ViewChild('mySidenav') myDiv!: ElementRef;
  constructor(private router: Router, public localStorageService: LocalStorageService){

  }
  links: Array<{ text: string, path: string  }> = [];
  
  ngOnInit(){
    // This is not necesary anymore, routing.module files add routes in imports: [RouterModule.forRoot(routes)],
    // this.router.config.push(...LoginRoutingModule.getRoutes());
    // this.router.config.push(...RegisterRoutingModule.getRoutes());

    this.router.config
    .filter(f=> f.data?.showInNavBar)
    .forEach(
      fe=> this.links.push(
        {text: fe.data?.name.toString(), path: fe.path ? fe.path : ''},
        ) );
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout(){
    this.localStorageService.removeUserData();
    this.toggle();
    this.router.navigate(['/login'])
  }

//   openNav() {
//     this.myDiv.nativeElement.getElementById("mySidenav").style.display = "block";
//     // document.getElementById("mySidenav").style.display = "block";
//   }
  
//  closeNav() {
//   this.myDiv.nativeElement.style.display = "none";
//     // document.getElementById("mySidenav").style.display = "none";
//   }
}
