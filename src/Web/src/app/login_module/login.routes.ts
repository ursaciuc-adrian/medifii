import { LoginComponent } from './pages/login/login.component';
import { Routes } from '@angular/router';
import { SignupComponent } from './pages/signup/signup.component';
export const LOGIN_ROUTES: Routes = [
    {
      path: 'login',
      component: LoginComponent
    },
    // {
    //   path: 'signup',
    //   component: SignupComponent
    // },
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    }
];
