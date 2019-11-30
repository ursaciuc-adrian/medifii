import { Routes } from '@angular/router';
export const APP_ROUTES: Routes = [
    {
        path: 'iamlazy',
        loadChildren: () => import('../lazy_module/lazy.module').then(m => m.LazyModule)
    },
    {
        path: '',
        redirectTo: '',
        pathMatch: 'full'
    }
];