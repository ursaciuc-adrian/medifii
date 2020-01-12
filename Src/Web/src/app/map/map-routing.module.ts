import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MapComponent } from './pages/map/map.component';
import { AuthGuard } from '../shared/guards/authentication.guard';


const routes: Routes = [{
  path: '',
  pathMatch: 'full',
  component: MapComponent,
  canActivate: [AuthGuard],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MapRoutingModule { }
