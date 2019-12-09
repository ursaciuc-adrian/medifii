import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProductComponent } from './pages/add-product/add-product.component';


const routes: Routes = [{
  path: 'add',
  pathMatch: 'full',
  component: AddProductComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
