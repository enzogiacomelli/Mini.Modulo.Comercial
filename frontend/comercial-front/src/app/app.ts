import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CreateOrderComponent } from './pages/create-order/create-order.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CreateOrderComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('comercial-front');
}
