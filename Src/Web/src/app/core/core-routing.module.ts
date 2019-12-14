import { CORE_ROUTES } from './core.routes';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [RouterModule.forChild(CORE_ROUTES)],
    exports: [RouterModule]
})
export class CoreRoutingModule { }
