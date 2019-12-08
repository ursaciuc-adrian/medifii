import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MapComponent } from './pages/map/map.component';


const routes: Routes = [{
  path: '',
  pathMatch: 'full',
  redirectTo: 'map'
},
{
  path: 'map',
  component: MapComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MapRoutingModule { }
