import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddProductComponent } from './pages/add-product/add-product.component';
import { ProductsRoutingModule } from './products.routing.module';
import { SharedModule } from '../shared/shared.module';
import { ProductsListComponent } from './pages/products-list/products-list.component';
import { RequestProductComponent } from './pages/request-product/request-product.component';
import { ConfirmDialogComponent } from '../shared/components/confirm-dialog/confirm-dialog.component';
import { ReserveProductComponent } from './pages/reserve-product/reserve-product.component';

import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

@NgModule({
  declarations: [
    ProductsListComponent,
    AddProductComponent,
    RequestProductComponent,
    ReserveProductComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ProductsRoutingModule,    
    OwlDateTimeModule,
    OwlNativeDateTimeModule
  ],
  entryComponents: [
    ConfirmDialogComponent
  ]
})
export class ProductsModule { }
