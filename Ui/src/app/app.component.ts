import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {ButtonModule} from 'primeng/button'
import { ToolbarModule } from 'primeng/toolbar';
import { AvatarModule } from 'primeng/avatar';
import {AngularOpenlayersModule} from "ng-openlayers";
import { SplitterModule } from 'primeng/splitter';
import { MapComponent } from './map/map.component';
import { MarkerService } from './marker.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MapPopupService } from './map-popup.service';
import { TreeTableModule } from 'primeng/treetable';
import { DataTableComponent } from './data-table/data-table.component';
import { DialogModule } from 'primeng/dialog';
import { UserComponent } from './user/user.component';
import { MeteoDataService } from './meteo-data.service';
import { FormsModule } from '@angular/forms';
import { MeteoStationDTO } from './model/MeteoStationDto';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ButtonModule, ToolbarModule, AvatarModule, 
    AngularOpenlayersModule, SplitterModule, MapComponent, 
    HttpClientModule, TreeTableModule, DataTableComponent, DialogModule, UserComponent, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [MarkerService, MapPopupService, MeteoDataService]
})
export class AppComponent {
  title = 'Ui';
  userId = -1;

  public visible: boolean = false;
  creatorId: number=1;

  meteoStationData: MeteoStationDTO = {
    id: 0,
    name: null,
    creator: null,
    meteoData: null,
    latitude: 0,
    longitude: 0
  };

  constructor(private http: HttpClient, private meteoService:MeteoDataService) {
  }

  handleUserId(userId: number) {
    this.userId = userId;
  }
  
  showDialog(){
    this.visible = true
  }

  closeDialog(){
    this.visible = false
  }

  logOut(){
    this.userId = -1;
  }

  onSubmit() {
    this.meteoStationData.creator = { id: this.creatorId, name: "null", userType: 0, isActive: true };
    this.meteoService.post(this.meteoStationData).subscribe(() => {
      this.closeDialog();
      location.reload();
    });
  }
}
