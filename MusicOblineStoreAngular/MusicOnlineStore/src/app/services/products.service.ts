import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Products } from '../models/product';

@Injectable({ providedIn: 'root' })
export class ProductsService {
    constructor(private http: HttpClient) { }

    getProducts() {
        return this.http.get<Products[]>(`https://localhost:44390/products`);
    }

}