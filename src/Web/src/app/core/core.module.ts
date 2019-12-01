import { CoreRoutingModule } from './core-routing.module';
import { NgModule } from '@angular/core';
import { HomeComponent } from './pages/home/home.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CoreRoutingModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: []
})
export class CoreModule { }
