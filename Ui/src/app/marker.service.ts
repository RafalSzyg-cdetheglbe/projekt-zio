import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as L from 'leaflet';

import { MapPopupService } from './map-popup.service';
import { MeteoData } from './model/meteoStation';

@Injectable({
  providedIn: 'root'
})
export class MarkerService { 
  meteoStations: string = '/assets/data/meteo-stations.geojson';
  //meteoStations: string = '/assets/data/usa-capitals.geojson';

  meteoList: MeteoData[] = [];
  constructor(private http: HttpClient, private popupService: MapPopupService) {
  }

  makeMeteoMarkers(map: L.Map): void {
    this.http.get(this.meteoStations).subscribe((res: any) => {
      for (const c of res.features) {
        const lon = c.geometry.coordinates[0];
        const lat = c.geometry.coordinates[1];
        const marker = L.marker([lat, lon]);

        marker.bindPopup(this.popupService.makeMeteoPopup(c.properties));

        marker.addTo(map);
      }
    });
  }


  createMeteoStationList(): MeteoData[] {
    // Empty the list before filling
    this.meteoList = []

    this.http.get(this.meteoStations).subscribe((res: any) => {

      for (const c of res.features) {
        let meteoStation: MeteoData = {
          id: c.properties.id,
          name: c.properties.name,
          longitude: c.geometry.coordinates[0], 
          latitude: c.geometry.coordinates[1],
          Temperature: c.properties.temperature,
          Humidity: c.properties.humidity,
          AtmosphericPressure: c.properties.pressure,
          Rainfall: c.properties.rainfall,
          WindSpeed: c.properties.windspeed
        };

        this.meteoList.push(meteoStation);
      }
    });

    return this.meteoList;
  }


}