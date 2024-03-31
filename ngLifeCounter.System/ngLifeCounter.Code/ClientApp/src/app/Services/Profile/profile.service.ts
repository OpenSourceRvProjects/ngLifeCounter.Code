import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LocalStorageService } from '../Storage/local-storage.service';
import { IImageListModel } from 'src/app/Models/Profile/IImageListModel';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private localStorage : LocalStorageService) { }

  private initHeaders() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization' : 'Bearer ' + this.localStorage.getUserData().token,
    })
    return headers;
  }


  addImagesToProfile(images : IImageListModel){
    var headers = this.initHeaders();
    return this.http.post(this.baseUrl + "api/Profile/addImages", images, {headers})
  }

  getProfileImages(){
    var headers = this.initHeaders();
    return this.http.get(this.baseUrl + "api/Profile/getImages", {headers})
  }

}
