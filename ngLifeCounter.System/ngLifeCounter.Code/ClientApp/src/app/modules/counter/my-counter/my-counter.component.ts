import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LocalStorageService } from 'src/app/Services/Storage/local-storage.service';

@Component({
  selector: 'app-my-counter',
  templateUrl: './my-counter.component.html',
  styleUrls: ['./my-counter.component.css']
})
export class MyCounterComponent {

  constructor(private localStorageService: LocalStorageService, private router: Router, private route: ActivatedRoute){}
  id: string = "";
  private sub: any;

  ngOnInit(){
    this.localStorageService.avtiveCounterView();
    this.sub = this.route.queryParams.subscribe(params=>{
      this.id = params['id'];
      this.getEvent();
    });
  }

  getEvent(){
      alert(this.id)
  }

  goToListPage() {
    this.router.navigate(['/counter/list']);
  }
}
