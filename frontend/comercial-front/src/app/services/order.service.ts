import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class OrderService {

    private apiUrl = '/api/orders';

    constructor(private http: HttpClient) {}

    getOrders(): any[] {
    return [];
    }

    createOrder(order: any) {
        return this.http.post(this.apiUrl, order);
    }
}
