import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ClientService } from '../../services/client.service';
import { OrderService } from '../../services/order.service';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-create-order',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {
  clients: any[] = [];
  products: any[] = [];
  productItems: Array<{ productId: number; quantity: number }> = [];
  selectedClientId: number | null = null;
  selectedProductId: number | null = null;
  selectedQuantity = 1;
  errorMessage = '';
  isLoading = false;

  constructor(
    private orderService: OrderService,
    private clientService: ClientService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.loadClients();
    this.loadProducts();
  }

  loadClients(): void {
    this.clientService.getClients().subscribe({
      next: (data) => {
        this.clients = Array.isArray(data) ? data : [];
      },
      error: () => {
        this.errorMessage = 'Erro ao carregar clientes.';
      }
    });
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe({
      next: (data) => {
        this.products = Array.isArray(data) ? data : [];
      },
      error: () => {
        this.errorMessage = 'Erro ao carregar produtos.';
      }
    });
  }

  addProduct(): void {
    if (!this.selectedProductId || this.selectedQuantity < 1) {
      return;
    }

    const existingItem = this.productItems.find(
      (item) => item.productId === this.selectedProductId
    );

    if (existingItem) {
      existingItem.quantity += this.selectedQuantity;
    } else {
      this.productItems.push({
        productId: this.selectedProductId,
        quantity: this.selectedQuantity
      });
    }

    this.selectedProductId = null;
    this.selectedQuantity = 1;
    this.errorMessage = '';
  }

  removeProduct(index: number): void {
    this.productItems.splice(index, 1);
  }

  getProductName(productId: number): string {
    return this.products.find((product) => product.id === productId)?.name || `Produto ${productId}`;
  }

  create(): void {
    if (!this.selectedClientId) {
      this.errorMessage = 'Selecione um cliente para o pedido.';
      return;
    }

    if (this.productItems.length === 0) {
      this.errorMessage = 'Adicione ao menos um item ao pedido.';
      return;
    }

    const order = {
      clientId: this.selectedClientId,
      items: this.productItems
    };

    this.isLoading = true;
    this.orderService.createOrder(order).subscribe({
      next: (res) => {
        console.log('Sucesso:', res);
        this.resetForm();
      },
      error: () => {
        this.errorMessage = 'Erro ao criar o pedido.';
      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }

  private resetForm(): void {
    this.selectedClientId = null;
    this.selectedProductId = null;
    this.selectedQuantity = 1;
    this.productItems = [];
    this.errorMessage = '';
  }
}
