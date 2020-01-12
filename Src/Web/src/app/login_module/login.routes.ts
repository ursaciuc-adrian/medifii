import { LoginComponent } from './pages/login/login.component'
import { Routes } from '@angular/router'
import { LoginGuard } from '../shared/guards/login.guard'

export const LOGIN_ROUTES: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [LoginGuard],
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
]
