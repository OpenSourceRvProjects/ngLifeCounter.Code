import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contavida',
  template: `
    <div class="container">
      <div role="alert" class="alert alert-success d-flex justify-content-center">
        <span style="margin-top: 8px;">
          Estamos emocionados de presentar la plataforma bajo una nueva marca.
          ContaVida estará disponible a partir del <strong>14 de Enero de 2026 </strong>,
          <a
            href="https://contavida.azurewebsites.net/"
            target="_blank"
            rel="noopener noreferrer"
          >
            Visítala aquí pronto
          </a>
        </span>
      </div>
    </div>
  `
})
export class ContavidaAppComponent implements OnInit {

  constructor() {}

  ngOnInit(): void {}
}
