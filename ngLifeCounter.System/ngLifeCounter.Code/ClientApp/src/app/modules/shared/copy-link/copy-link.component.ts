import { Component, Inject, Input } from '@angular/core';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

@Component({
  selector: 'app-copy-link',
  templateUrl: './copy-link.component.html',
  styleUrls: ['./copy-link.component.css']
})
export class CopyLinkComponent {


  constructor(@Inject('BASE_URL') private baseUrl : any, private localStorageService : LocalStorageService) {
    
  }

  @Input()
  counterID: string = "";
  @Input()
  isFromCounterView: boolean = false;

  ngOnInit(){
    if (!this.isFromCounterView){
    this.localStorageService.desactivateCounterView();
    }
  }

 

  copyUrl(){
    debugger;
    const selBox = document.createElement('textarea');
    selBox.style.position = 'fixed';
    selBox.style.left = '0';
    selBox.style.top = '0';
    selBox.style.opacity = '0';
    selBox.value = this.baseUrl + "counter/myCounter?id=" + this.counterID + "&shared=true";
    document.body.appendChild(selBox);
    selBox.focus();
    selBox.select();
    var urlString = selBox.value;
    navigator.clipboard.writeText(urlString);
    // document.execCommand('copy', false);
    document.body.removeChild(selBox);
    alert("Copiaste tu contador! puedes compartirlo públicamente")
  }


}
