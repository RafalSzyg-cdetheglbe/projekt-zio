import { AfterViewInit, Component } from '@angular/core';
import { MarkerService } from '../marker.service';
import { MeteoData } from '../model/meteoStation';
import { TreeTableModule } from 'primeng/treetable';
import { TableModule } from 'primeng/table';
import { MeteoStationDTO } from '../model/MeteoStationDto';
import { MeteoDataService } from '../meteo-data.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-data-table',
  standalone: true,
  imports: [TreeTableModule, TableModule, CommonModule],
  templateUrl: './data-table.component.html',
  styleUrl: './data-table.component.css'
})
export class DataTableComponent implements AfterViewInit {

  meteoList: MeteoStationDTO[] = [];

  ngAfterViewInit(): void {
    const meteos$ = this.meteoDataService.get();
    meteos$.subscribe({
      next: (x) => {
        console.log('next ', x)
        this.meteoList = x
        
        for (var m of this.meteoList)
          {
            m.meteoData = m.meteoData?.slice(-5) !== undefined ? m.meteoData?.slice(-5) : null
            console.log('dlugosc: ', m.meteoData?.length)
          }
      },
      error: (x) => { console.log('error ', x) },
      complete: () => { console.log('complete ') }
    })
  }
  
  constructor(private meteoDataService: MeteoDataService) { }
}
