import { Routes } from '@angular/router';
import { AuthGuard } from '../shared/guards/authentication.guard';
import { LoginGuard } from '../shared/guards/login.guard';
export const APP_ROUTES: Routes = [
    {
        path: 'auth',
        loadChildren: () => import('../login_module/login.module').then(m => m.LoginModule),
        canActivate: [LoginGuard],
    },
    {
        path: 'app',
        loadChildren: () => import('../core/core.module').then(m => m.CoreModule),
        canActivate: [AuthGuard],
    },
    {
        path: 'map',
        loadChildren: () => import('../map/map.module').then(m => m.MapModule),
        canActivate: [AuthGuard],
    },
    {
        path: 'products',
        loadChildren: () => import('../products/products.module').then(m => m.ProductsModule),
        canActivate: [AuthGuard],
    },
    {
        path: '',
        redirectTo: 'app',
        pathMatch: 'full'
    }
];