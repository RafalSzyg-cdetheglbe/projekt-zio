import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as L from 'leaflet';

import { MapPopupService } from './map-popup.service';
import { MeteoData } from './model/meteoStation';
import { MeteoDataService } from './meteo-data.service';
import { MeteoStationDTO } from './model/MeteoStationDto';

@Injectable({
  providedIn: 'root'
})
export class MarkerService {
  meteoStations: string = '/assets/data/meteo-stations.geojson';
  //meteoStations: string = '/assets/data/usa-capitals.geojson';


  public meteoStationList: MeteoStationDTO[] = []

  constructor(private http: HttpClient, private popupService: MapPopupService, private meteoDataService: MeteoDataService) {

  }

  getMeteoList() {
    console.log("Aaaaaa2 " + this.meteoStationList.length)
    const meteos$ = this.meteoDataService.get();
    meteos$.subscribe({
      next: (x) => {
        console.log('next ', x)
        this.meteoStationList = x
      },
      error: (x) => { console.log('error ', x) },
      complete: () => { console.log('complete ') }
    })

  }

  makeMeteoMarkers(map: L.Map): void {
    const meteos$ = this.meteoDataService.get();
    meteos$.subscribe({
      next: (x) => {
        console.log('next ', x)
        this.meteoStationList = x

        for (const ms of this.meteoStationList) {
          const lon = ms.longitude
          const lat = ms.latitude
          const marker = L.marker([lat, lon]);


          marker.bindPopup(this.popupService.makeMeteoPopup(ms));


          marker.addTo(map);
        }
      },
      error: (x) => { console.log('error ', x) },
      complete: () => { console.log('complete ') }
    })
  }

  createMeteoStationList(): MeteoStationDTO[] {
    
    return this.meteoStationList
  }

  meteoList: MeteoData[] = [];

  makeMeteoMarkersFromGeoJson(map: L.Map): void {
    this.http.get(this.meteoStations).subscribe((res: any) => {
      for (const c of res.features) {
        const lon = c.geometry.coordinates[0];
        const lat = c.geometry.coordinates[1];
        const marker = L.marker([lat, lon]);

        marker.bindPopup(this.popupService.makeMeteoPopupFromGeoJson(c.properties));

        marker.addTo(map);
      }
    });
  }

  createMeteoStationListFromGeoJson(): MeteoData[] {
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