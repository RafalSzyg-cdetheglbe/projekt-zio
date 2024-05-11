import { Injectable } from '@angular/core';
import { MeteoDataDTO } from './model/MeteoDataDto';
import { MeteoStationDTO } from './model/MeteoStationDto';

@Injectable({
  providedIn: 'root'
})
export class MapPopupService {

  constructor() { }

  makeMeteoPopup(data: MeteoStationDTO): string {
    var popupinfo = ''

    if (data) {
      popupinfo += `<div>Nazwa: ${data.name}</div>`
      if (data.creator) {
        popupinfo += `<div>Stworzono przez: ${data.creator.name}</div>`
      }

      popupinfo += `<div>Longitude ${data.longitude}</div>`
      popupinfo += `<div>Latitude: ${data.latitude}</div>`

      if (data.meteoData) {
        for (const md of data.meteoData) {
          popupinfo += `<div> ${md.name}: ${md.value} ${md.unit} </div>`
        }
      }
    }
    return popupinfo;
  }

  makeMeteoPopupFromGeoJson(data: any): string {
    return `` +
      `<div>Nazwa: ${data.name}</div>` +
      `<div>Temperatura: ${data.temperature}</div>` +
      `<div>Ciśnienie: ${data.pressure}</div>`
  }
}
