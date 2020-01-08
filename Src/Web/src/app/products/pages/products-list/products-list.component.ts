import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { AddProductComponent } from '../add-product/add-product.component';
import { RequestProductComponent } from '../request-product/request-product.component';
import { ProductsService } from '../../services/products/products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {
  private isPharmacist: boolean = false;
  private products: Product[];
  private displayedColumns: string[] = ['name', 'description', 'price', 'expiryDate', 'quantity', 'deliveryOption', 'availability', 'actions']
  private dataSource: MatTableDataSource<Product>;
  constructor(public dialog: MatDialog,
    private productsService: ProductsService) { }

  ngOnInit() {
    this.productsService.getAllProducts().subscribe(products => {
      this.products = products;
      this.dataSource  = new MatTableDataSource<Product>(this.products);
      console.log(this.products);
    });
  }

  search(searchValue: string) {
    this.dataSource.filter = searchValue.trim().toLowerCase();
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(AddProductComponent, {
      data: {
        isEdit: false
      }
    });
    dialogRef.afterClosed().subscribe(createdProduct => {
      this.productsService.addProduct(createdProduct).subscribe(res => console.log(res));
    })
  }

  openRequestDialog(product: Product): void {
    const dialogRef = this.dialog.open(RequestProductComponent, {

    });
  }

  toggle(): void {
    this.isPharmacist = !this.isPharmacist;
  }

}
