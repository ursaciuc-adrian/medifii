import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../../models/product';
import { MatSnackBar } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private productsEndpoint: string = '/api/Product';
  constructor(private http: HttpClient,
    private _snackBar: MatSnackBar) { }

  getAllProducts(): Observable<any> {
    return this.http.get(`${this.productsEndpoint}`);
  }

  addProduct(product: Product): Observable<any> {
    return this.http.post(`${this.productsEndpoint}`, product);
  }

  getProduct(productId: string): Observable<any> {
    return this.http.get(`${this.productsEndpoint}/${productId}`);
  }

  updateProduct(product: Product): Observable<any> {
    return this.http.put(`${this.productsEndpoint}/${product.id}`, product);
  }

  deleteProduct(productId): Observable<any> {
    return this.http.delete(`${this.productsEndpoint}/${productId}`);
  }

  showMessage(message): void {
    this._snackBar.open(message, 'x', {
      duration: 2000,
      verticalPosition: 'top',
      horizontalPosition: 'right'
    });
  }
}
