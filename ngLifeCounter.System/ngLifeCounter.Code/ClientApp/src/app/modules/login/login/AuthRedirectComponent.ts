import { Component } from "@angular/core";

@Component({
  selector: 'app-auth-redirect',
  template: `<p>Procesando inicio de sesión...</p>`
})
export class AuthRedirectComponent {
  constructor() { }

  ngOnInit(): void {
    // Let MSAL process the hash here before Angular does anything else
  }
}
