import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product';
import { MatTableDataSource, MatDialog, MatSnackBar } from '@angular/material';
import { AddProductComponent } from '../add-product/add-product.component';
import { RequestProductComponent } from '../request-product/request-product.component';
import { ProductsService } from '../../services/products/products.service';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { ReserveProductComponent } from '../reserve-product/reserve-product.component';
import * as moment from 'moment';
import { LoginService } from 'src/app/shared/services/login.service';
@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {
  private isPharmacist: boolean = false;
  private products: Product[];
  private displayedColumns: string[] = ['name', 'description', 'price', 'expiryDate', 'quantity', 'availability', 'actions']
  private dataSource: MatTableDataSource<Product>;
  constructor(public dialog: MatDialog,
    private productsService: ProductsService,
    private _snackBar: MatSnackBar,
    private loginService: LoginService) {
    if (this.loginService.isAuthenticated() == 2) {
      this.isPharmacist = false;
    } else {
      this.isPharmacist = true;
    }
  }

  ngOnInit() {
    this.setDataSource();
  }

  setDataSource(): void {
    this.productsService.getAllProducts().subscribe(products => {
      this.products = products.map(product => {
        product.expiryDate = moment(product.expiryDate).format('DD-MM-YYYY')
        return product;
      });
      this.dataSource = new MatTableDataSource<Product>(this.products);
    }, () => this.productsService.showMessage('An error occured!'));
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
      if (createdProduct) {
        this.productsService.addProduct(createdProduct).subscribe(() => {
          this.productsService.showMessage('Product added!');
        }, () => this.productsService.showMessage('An error occured!'),
          () => this.setDataSource());
      }
    });
  }

  openEditDialog(product: Product): void {
    const dialogRef = this.dialog.open(AddProductComponent, {
      data: {
        isEdit: true,
        product: product
      }
    });
    dialogRef.afterClosed().subscribe(updatedProduct => {
      if (updatedProduct) {
        this.productsService.updateProduct(updatedProduct).subscribe(() => {
          this.productsService.showMessage('Product updated!');
        }, () => this.productsService.showMessage('An error occured!'),
          () => this.setDataSource());
      }
    });
  }

  openRequestDialog(product: Product): void {
    const dialogRef = this.dialog.open(RequestProductComponent, {

    });
  }

  openReserveDialog(productId: string): void {
    const dialogRef = this.dialog.open(ReserveProductComponent, {});
    dialogRef.afterClosed().subscribe(value => {
      const dict = {
        'productId': productId,
        'pharmacyId': value.pharmacyId,
        'quantity': value.quantity,
        'pickupTime': value.pickupTime
      };

      this.productsService.addReserve(dict).subscribe(_ => {
        this.showMessage('Request added succesfully!');
      },
        error => {
          this.showMessage('Something went wrong.');
        });
    })
  }

  deleteProduct(product: Product): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: {
        title: `Delete ${product.name}`,
        message: 'Are you sure you want to delete this product?'
      }
    });
    dialogRef.afterClosed().subscribe(res => {
      if (res) {
        this.productsService.deleteProduct(product.id).subscribe(() => {
          this.productsService.showMessage('Product deleted!');
        }, () => this.productsService.showMessage('An error occured!'),
          () => this.setDataSource());
      }
    });
  }



  toggle(): void {
    this.isPharmacist = !this.isPharmacist;
  }
  showMessage(message): void {
    this._snackBar.open(message, 'x', {
      duration: 2000,
      verticalPosition: 'top',
      horizontalPosition: 'right',
    })
  }
}
