import { Component } from '@angular/core';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-create-order',
  standalone: true,
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent {
    constructor(private orderService: OrderService) {}

    create(){
        const order = {
            clientId: 1,
            items: [
                {productId: 1, quantity: 2},
            ]
    };

    this.orderService.createOrder(order).subscribe({
      next: (res) => console.log('Sucesso:', res),
      error: (err) => console.error('Erro:', err)
    });
  }
}
