import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {ButtonModule} from 'primeng/button'
import { ToolbarModule } from 'primeng/toolbar';
import { AvatarModule } from 'primeng/avatar';
import {AngularOpenlayersModule} from "ng-openlayers";
import { SplitterModule } from 'primeng/splitter';
import { MapComponent } from './map/map.component';
import { MarkerService } from './marker.service';
import { HttpClientModule } from '@angular/common/http';
import { MapPopupService } from './map-popup.service';
import { TreeTableModule } from 'primeng/treetable';
import { DataTableComponent } from './data-table/data-table.component';
import { DialogModule } from 'primeng/dialog';
import { UserComponent } from './user/user.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ButtonModule, ToolbarModule, AvatarModule, 
    AngularOpenlayersModule, SplitterModule, MapComponent, 
    HttpClientModule, TreeTableModule, DataTableComponent, DialogModule, UserComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [MarkerService, MapPopupService]
})
export class AppComponent {
  title = 'Ui';
}