import { Routes } from '@angular/router';
export const APP_ROUTES: Routes = [
    {
        path: 'auth',
        loadChildren: () => import('../lazy_module/login.module').then(m => m.LoginModule)
    },
    // {
    //     path: 'home',
    //     loadChildren: () => import('../lazy_module/lazy.module').then(m => m.LazyModule)
    // },
    {
        path: '',
        redirectTo: 'auth',
        pathMatch: 'full'
    }
];