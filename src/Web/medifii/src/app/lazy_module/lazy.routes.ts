import { TestComp } from './pages/test_comp/test_comp.component';
import { Routes } from '@angular/router';
export const LAZY_ROUTES: Routes = [
    {
      path: '',
      component: TestComp
    },
    {
        path: '',
        redirectTo: '',
        pathMatch: 'full'
    }
];