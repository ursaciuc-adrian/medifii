import { LAZY_ROUTES } from './lazy.routes';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [RouterModule.forChild(LAZY_ROUTES)],
    exports: [RouterModule]
})
export class LazyRoutingModule { }