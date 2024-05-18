import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LocalStorageService } from '../Storage/local-storage.service';
import { IImageListModel } from 'src/app/Models/Profile/IImageListModel';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private localStorage : LocalStorageService) { }

  addImagesToProfile(images : IImageListModel){
    return this.http.post(this.baseUrl + "api/Profile/addImages", images)
  }

  getProfileImages(){
    return this.http.get(this.baseUrl + "api/Profile/getImages")
  }

}
