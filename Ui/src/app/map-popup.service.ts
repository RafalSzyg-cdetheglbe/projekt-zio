import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MapPopupService {

  constructor() { }
  makeMeteoPopup(data: any): string {
    return `` +
      `<div>Nazwa: ${data.name}</div>` +
      `<div>Temperatura: ${data.temperature}</div>` +
      `<div>Ciśnienie: ${data.pressure}</div>`
  }
}
