import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
export const CORE_ROUTES: Routes = [
    {
      path: 'home',
      component: HomeComponent
    },
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    }
];