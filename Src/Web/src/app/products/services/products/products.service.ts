import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private productsEndpoint: string = 'https://localhost:5001/api/Product';
  constructor(private http: HttpClient) { }

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
}
