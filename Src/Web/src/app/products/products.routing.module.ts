import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProductComponent } from './pages/add-product/add-product.component';
import { ProductsListComponent } from './pages/products-list/products-list.component';
import { RequestProductComponent } from './pages/request-product/request-product.component';


const routes: Routes = [
  {
    path: '',
    component: ProductsListComponent
  },
  {
    path: 'add',
    pathMatch: 'full',
    component: AddProductComponent
  },
  {
    path: 'request',
    component: RequestProductComponent
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
