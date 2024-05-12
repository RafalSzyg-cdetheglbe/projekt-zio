import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MeteoStationDTO } from './model/MeteoStationDto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MeteoDataService {
  private readonly URL = "https://localhost:7013/api/MeteoStations";

  constructor(private httpClient: HttpClient) { }

  get(): Observable<MeteoStationDTO[]> {
      return this.httpClient.get<MeteoStationDTO[]>(this.URL);
  }

  post(meteoStation: MeteoStationDTO): Observable<any> {
    return this.httpClient.post<any>(this.URL, meteoStation);
  }

 
}
