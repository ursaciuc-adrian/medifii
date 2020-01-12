import { Routes } from '@angular/router'
import { HomeComponent } from './pages/home/home.component'
import { AuthGuard } from '../shared/guards/authentication.guard'
export const CORE_ROUTES: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
]
