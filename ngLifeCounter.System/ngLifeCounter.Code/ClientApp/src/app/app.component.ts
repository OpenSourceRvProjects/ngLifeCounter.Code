import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';
  dotnetVersion: string | null = null;



  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    var currentDate = new Date();

    if (currentDate > new Date(2026, 0, 14)) {

      window.location.href = 'https://contavida.azurewebsites.net/';
    }

    this.http.get<{ dotnetVersion: string }>('/api/Account/dotnetVersion')
      .subscribe({
        next: res => this.dotnetVersion = res?.dotnetVersion ?? null,
        error: () => this.dotnetVersion = null
      });
  }
}
