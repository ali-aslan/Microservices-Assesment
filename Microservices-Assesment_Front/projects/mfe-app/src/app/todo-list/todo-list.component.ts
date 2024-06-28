import { ChangeDetectorRef, Component } from '@angular/core';
import { MfeService } from '../mfe.service';

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
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss']
})
export class TodoListComponent {

  constructor(private cdr: ChangeDetectorRef,private saleService: MfeService) {}



  //#region Customer
  customer: Customer = { id: '', name: '', email: '', phone: ''};
  customerPageData: any ;
  
    customerSubmit(cus: Customer) {
      this.saleService.addCustomer(cus).subscribe(
        (response) => {
          alert('customer added successfully');
        },
        (error) => {
          alert('customer not added.'+ error.error);
        }
      );
      this.customer = { id: '', name: '', email: '', phone: ''};
      this.cdr.detectChanges();
    }
  
    getCustomers() { 
      this.saleService.getCustomers(0, 10).subscribe(
      (data) => {
        this.customerPageData = data;
        alert('customer get successfully!');
      },
      (error) => {
        if (error.status === 401 || error.status === 403) {
          alert('Unauthorized access. Please log in again.');
        } else {
          alert('Failed to retrieve customers: ' + error.error);
        }
      }
    );
    }
  
    deleteCustomer(id:string) {
      this.saleService.deleteCustomerById(id).subscribe(
        response => {
          alert('customer deleted successfully!');
        },
        (error) => {
          if (error.status === 401 || error.status === 403) {
            alert('Unauthorized access. Please log in again.');
          } else {
          alert('Customer not deleted.'+ error.error);
          }
        }
      );
    } 
  
    //#endregion
  
    //#region Product
  product: Product = { id: '', name: '', categoryName: '', price: 0, stockQuantity: 0};
  productPageData: any ;
  
  
    productSubmit(product: Product) {
      this.saleService.addProduct(product).subscribe(
        (response) => {
          alert("Product added successfully");
        },
        (error) => {
          alert('PRoduct not added.'+ error.error);
        }
      );
      this.product = { id: '', name: '', categoryName: '', price: 0, stockQuantity: 0};
      this.cdr.detectChanges();
    }
  
    getProducts() { 
      this.saleService.getProducts(0, 10).subscribe(
      (data) => {
        this.productPageData = data;
        alert('Product List get successfully!');
      },
      (error) => {
        if (error.status === 401 || error.status === 403) {
          alert('Unauthorized access. Please log in again.');
        } else {
        alert('Product List not get.'+ error.error);
      }
    }
    );
    this.cdr.detectChanges();
    }
  
    deleteProduct(id:string) {
      console.log(id)
      this.saleService.deleteProductById(id).subscribe(
        response => {
          alert('Product deleted successfully!');
          this.cdr.detectChanges();
        },
        error => {
          alert('Product not deleted.'+ error.error);
        }
      );
    }
  
  
   //#endregion
  
   //#region  Order
   order: Order = { id: '', orderDate: '', customerID: '', productID: '',supplierID: '', shipperID: '', sellerID: '' };
   orderPageData: any ;
   orderGetByCustomerId = {customerID: ''} ;
   orderById:  any ;
  
    orderSubmit(order: Order) {
      this.saleService.addOrder(order).subscribe(
        (response) => {
          alert('Order added successfully');
        },
        (error) => {
          alert('Order not added.'+ error.error);
        }
      );
      this.order = { id: '', orderDate: '', customerID: '', productID: '',supplierID: '', shipperID: '', sellerID: '' };
      this.cdr.detectChanges();
    }
  
    getOrders() { 
      this.saleService.getOrders(0, 10).subscribe(
      (data) => {
        this.orderPageData = data;
        alert('Order List get successfully!');
      },
      (error) => {
        alert('Order List not get.'+ error.error);
      }
    );
    }
  
    getOrderByCustomerId(id:string) {
      this.saleService.getOrderByCustomerId(id).subscribe(
        (data) => {
          this.orderById = data;
          alert('Order  get successfully!');
        },
        (error) => {
          alert('Order not get.'+ error.error);
        }
      );
    }
    //#endregion
  
  

}
