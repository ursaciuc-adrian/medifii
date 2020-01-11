import { LoginComponent } from './pages/login/login.component';
import { Routes } from '@angular/router';

export const LOGIN_ROUTES: Routes = [
    {
      path: 'login',
      component: LoginComponent
    },
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    }
];
