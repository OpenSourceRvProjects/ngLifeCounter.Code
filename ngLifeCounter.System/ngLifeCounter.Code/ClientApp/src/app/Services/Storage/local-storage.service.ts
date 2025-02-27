import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  saveUserData(user: any) {
    localStorage.setItem("ngLifeCounter.ObjectInfo", JSON.stringify(user));
  }

  swapToLoginImpersonate (user: any){
    let originalUser = localStorage.getItem("ngLifeCounter.ObjectInfo");
    if (originalUser !== null){
      localStorage.setItem("ngLifeCounter.ObjectInfo.admin", originalUser);
      localStorage.setItem("ngLifeCounter.ObjectInfo", JSON.stringify(user));
    }

  }

  avtiveCounterView(){
    localStorage.setItem("ngLifeCounter.IsCounterViwe", "1")
  }

  desactivateCounterView(){
    localStorage.removeItem("ngLifeCounter.IsCounterViwe");
  }

  removeUserData(){
    localStorage.removeItem("ngLifeCounter.ObjectInfo");
    localStorage.removeItem("ngLifeCounter.ObjectInfo.admin");
  }

  getUserData(){
    let data = localStorage.getItem("ngLifeCounter.ObjectInfo");
    if (data !== null)
      return JSON.parse(data);
    else 
      return false;
  }

  isCounterActive() {
    let data = localStorage.getItem("ngLifeCounter.IsCounterViwe");
    if (data !== null)
    return true;
      else 
      return false;
  }
}
