import { Routes } from '@angular/router';
export const APP_ROUTES: Routes = [
    {
        path: 'auth',
        loadChildren: () => import('../login_module/login.module').then(m => m.LoginModule)
    },
    {
        path: 'app',
        loadChildren: () => import('../core/core.module').then(m => m.CoreModule)
    },
    {
        path: 'map',
        loadChildren: () => import('../map/map.module').then(m => m.MapModule)
    },
    {
        path: 'products',
        loadChildren: () => import('../products/products.module').then(m => m.ProductsModule)
    },
    {
        path: '',
        redirectTo: 'app',
        pathMatch: 'full'
    }
];