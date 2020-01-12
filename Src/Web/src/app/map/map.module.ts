import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MapRoutingModule } from './map-routing.module';
import { MapComponent } from './pages/map/map.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [MapComponent],
  imports: [
    SharedModule,
    MapRoutingModule,
  ]
})
export class MapModule { }
