import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { AddProductComponent } from '../add-product/add-product.component';
import { RequestProductComponent } from '../request-product/request-product.component';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {
  private isPharmacist: boolean = false;
  private mockData: Product[] = [
    new Product('Diazepam', 15.25, new Date('2020-01-15'), 100, 'Courier', 'On stock'),
    new Product('Theraflu', 2.5, new Date('2020-06-15'), 50, 'Courier', 'Out of stock'),
    new Product('Fervex', 1.5, new Date('2020-01-15'), 50, 'Personal pickup', 'Out of stock')
  ];
  private displayedColumns: string[] = ['name', 'description', 'price', 'expiryDate', 'quantity', 'deliveryOption', 'availability', 'actions']
  private dataSource = new MatTableDataSource<Product>(this.mockData);
  constructor(public dialog: MatDialog) { }

  ngOnInit() {
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
  }

  openRequestDialog(product: Product): void {
    const dialogRef = this.dialog.open(RequestProductComponent, {

    });
  }

  toggle(): void {
    this.isPharmacist = !this.isPharmacist;
  }

}
