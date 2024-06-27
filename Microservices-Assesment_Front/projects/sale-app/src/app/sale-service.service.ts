import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer, Product,Order } from './sale-panel/sale-panel.component';

@Injectable({
  providedIn: 'root'
})
export class SaleServiceService {

  private SaleCustomerUrl = 'https://localhost:44363/api/Customer';
  private SaleProductUrl = 'https://localhost:44363/api/Product';
  private SaleOrderUrl = 'https://localhost:44363/api/Order';

  constructor(private http: HttpClient) { }


  //#region Customer
  addCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.SaleCustomerUrl, customer);
  }

  getCustomers(pageIndex: number, pageSize: number): Observable<Customer[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

    return this.http.get<Customer[]>(this.SaleCustomerUrl, { params });
  }

  deleteCustomerById(id: string): Observable<any> {
    return this.http.delete(`${this.SaleCustomerUrl}/${id}`);
  }
  //#endregion


  //#region Product
  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.SaleProductUrl, product);
  }

  getProducts(pageIndex: number, pageSize: number): Observable<Product[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

      return this.http.get<Product[]>(this.SaleProductUrl, { params });
  }

  deleteProductById(id: string): Observable<any> {
    return this.http.delete(`${this.SaleProductUrl}/${id}`);
  }
  //#endregion


  //#region Order
  addOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(this.SaleOrderUrl, order);
  }

  getOrders(pageIndex: number, pageSize: number): Observable<Order[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

      return this.http.get<Order[]>(this.SaleOrderUrl, { params });
  }

  getOrderByCustomerId(id: string): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.SaleOrderUrl}/Customer/${id}`);
  }
  //#endregion
}
