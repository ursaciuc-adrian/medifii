import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { AuthGuard } from '../shared/guards/authentication.guard'
import { ResolveRequest } from './pages/resolve-request/resolve-request.component'

const routes: Routes = [
  {
    path: '',
    component: ResolveRequest,
    canActivate: [AuthGuard],
  },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RequestsRoutingModule {}
