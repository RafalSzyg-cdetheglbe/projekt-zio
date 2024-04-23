import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MapPopupService {

  constructor() { }
  makeCapitalPopup(data: any): string {
    return `` +
      `<div>Nazwa: ${data.name}</div>` +
      `<div>Temperatura: ${data.temperature}°C</div>` +
      `<div>Ciśnienie: ${data.pressure} hPa</div>`
  }
}
