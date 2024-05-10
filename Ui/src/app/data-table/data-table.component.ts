import { AfterViewInit, Component } from '@angular/core';
import { MarkerService } from '../marker.service';
import { MeteoData } from '../model/meteoStation';
import { TreeTableModule } from 'primeng/treetable';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-data-table',
  standalone: true,
  imports: [TreeTableModule, TableModule],
  templateUrl: './data-table.component.html',
  styleUrl: './data-table.component.css'
})
export class DataTableComponent implements AfterViewInit {

  meteoList: MeteoData[] = [];

  ngAfterViewInit(): void {
    this.meteoList = this.markerService.createMeteoStationList()
  }
  
  constructor(private markerService: MarkerService) { }
}
