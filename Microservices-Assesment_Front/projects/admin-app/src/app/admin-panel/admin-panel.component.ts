import { Component } from '@angular/core';
import { AdminServiceService } from '../admin-service.service';

export interface Customer {
  id: string;
  name: string;
  email: string;
  phone: string;
}

export interface Product {
  id: string;
  name: string;
  categoryName: string;
  price: number;
  stockQuantity: number;
}

export interface Supplier {
  id: string;
  name: string;
  contactName: string;
  phone: string;
}

export interface Shipper {
  id: string;
  name: string;
  phone: string;
}

export interface Seller {
  email: string;
}

export interface Order {
  id: string;
  customer: Customer;
  product: Product;
  supplier: Supplier;
  shipper: Shipper;
  seller: Seller;
}
@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent {
  orders: Order[] = [];

  constructor(private adminService: AdminServiceService) {}

  fetchOrders(): void {
    this.adminService.fetchOrders().subscribe(
      (orderData) => {
        this.orders = [];
  
        this.orders.push(orderData);
  
        alert('Order Fetch Successfully!');
      },
      (error) => {
     
        alert('Order Fetch Failed! ' + error.error);
      }
    );
  }

}
