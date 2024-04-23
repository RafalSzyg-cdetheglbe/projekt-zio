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



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ButtonModule, ToolbarModule, AvatarModule, AngularOpenlayersModule, SplitterModule, MapComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [MarkerService, MapPopupService]
})
export class AppComponent {
  title = 'Ui';
}