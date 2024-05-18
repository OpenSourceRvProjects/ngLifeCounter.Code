import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LocalStorageService } from '../Services/Storage/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class UserGuard  {

  constructor(private storageService: LocalStorageService, private router: Router){

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.storageService.getUserData() && !this.storageService.getUserData().isSysAdmin) {
        return true;
      }
      else{
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;

      }
      // return true;
  }
  
}
