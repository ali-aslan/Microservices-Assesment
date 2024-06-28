import { ChangeDetectorRef, Component } from '@angular/core';
import { SaleServiceService } from '../sale-service.service';
import * as e from 'cors';
import { from } from 'rxjs';

export interface Customer {
  id: string;
  name: string;
  email: string;
  phone: string;
}

export interface CustomerResponse {
  items: Customer[];
  size: number;
  index: number;
  count: number;
  pages: number;
  hasPrevious: boolean;
  hasNext: boolean;
}

export interface Product {
  id: string;
  name: string;
  categoryName: string;
  price: number;
  stockQuantity: number;
}

export interface Order {
  id: string;
  orderDate: string;
  customerID: string;
  productID: string;
  supplierID: string;
  shipperID: string;
  sellerID: string;
}

@Component({
  selector: 'app-sale-panel',
  templateUrl: './sale-panel.component.html',
  styleUrls: ['./sale-panel.component.scss']
})
export class SalePanelComponent {

  constructor(private cdr: ChangeDetectorRef,private saleService: SaleServiceService) {}




}