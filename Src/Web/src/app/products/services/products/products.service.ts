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
  private requestEndpoint: string = '/api/Request';
  constructor(private http: HttpClient,
    private _snackBar: MatSnackBar) { }

  getAllProducts(): Observable<any> {
    return this.http.get(`${this.productsEndpoint}/get`);
  }

  addRequest(request) {
    return this.http.post(`${this.requestEndpoint}/create`, request).toPromise();
  }

  getAllRequests(){
    return this.http.get(`${this.requestEndpoint}/get`);
  }

  addProduct(product: Product): Observable<any> {
    return this.http.post(`${this.productsEndpoint}/create`, product);
  }

  getProduct(productId: string): Observable<any> {
    return this.http.get(`${this.productsEndpoint}/${productId}`);
  }

  updateProduct(product: Product): Observable<any> {
    return this.http.put(`${this.productsEndpoint}/update/${product.id}`, product);
  }

  deleteProduct(productId): Observable<any> {
    return this.http.delete(`${this.productsEndpoint}/delete/${productId}`);
  }

  showMessage(message): void {
    this._snackBar.open(message, 'x', {
      duration: 2000,
      verticalPosition: 'top',
      horizontalPosition: 'right'
    });
  }
}
