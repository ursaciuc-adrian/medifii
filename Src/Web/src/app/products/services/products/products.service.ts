import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private productsEndpoint: string = 'http://localhost:7000/api/products/';
  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<any> {
    return this.http.get(`${this.productsEndpoint}`);
  }

  addProduct(product: Product) {
    return this.http.put(`${this.productsEndpoint}/add`, { product });
  }
}
