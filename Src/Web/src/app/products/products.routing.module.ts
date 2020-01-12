import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { AddProductComponent } from './pages/add-product/add-product.component'
import { ProductsListComponent } from './pages/products-list/products-list.component'
import { RequestProductComponent } from './pages/request-product/request-product.component'
import { ReserveProductComponent } from './pages/reserve-product/reserve-product.component'
import { AuthGuard } from '../shared/guards/authentication.guard'

const routes: Routes = [
  {
    path: '',
    component: ProductsListComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'add',
    pathMatch: 'full',
    component: AddProductComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'request',
    component: RequestProductComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'reserve',
    component: ReserveProductComponent,
    canActivate: [AuthGuard],
  },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductsRoutingModule {}
