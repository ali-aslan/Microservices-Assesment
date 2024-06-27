import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from './admin-panel/admin-panel.component';


export interface Customer {
  id: string;
  name: string;
  email: string;
  phone: string;
}


@Injectable({
  providedIn: 'root'
})
export class AdminServiceService {

  private SaleCustomerUrl = 'https://localhost:44387/api/Customer';
  private AdminOrderUrl = 'https://localhost:44387/api/Admin';


  constructor(private http: HttpClient) { }

  addCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.SaleCustomerUrl, customer);
  }

  getCustomers(pageIndex: number, pageSize: number): Observable<Customer[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

    return this.http.get<Customer[]>(this.SaleCustomerUrl, { params });
  }

  fetchOrders(): Observable<Order> {
    return this.http.get<Order>(this.AdminOrderUrl);
  }
}
