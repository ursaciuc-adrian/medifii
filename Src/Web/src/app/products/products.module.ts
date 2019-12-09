import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddProductComponent } from './pages/add-product/add-product.component';
import { ProductsRoutingModule } from './products.routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [AddProductComponent],
  imports: [
    CommonModule,
    SharedModule,
    ProductsRoutingModule
  ]
})
export class ProductsModule { }
