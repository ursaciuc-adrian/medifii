import { LazyRoutingModule } from './lazy-routing.module';
import { TestComp } from './pages/test_comp/test_comp.component';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [
      TestComp
  ],
  imports: [
    LazyRoutingModule
  ],
  providers: [],
  bootstrap: []
})
export class LazyModule { }
