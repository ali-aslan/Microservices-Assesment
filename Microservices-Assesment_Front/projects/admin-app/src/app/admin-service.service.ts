import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
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

  getToken() {
    return localStorage.getItem('token')
  }

  addCustomer(customer: Customer): Observable<Customer> {

    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

    return this.http.post<Customer>(this.SaleCustomerUrl, customer, { headers });
  }

  getCustomers(pageIndex: number, pageSize: number): Observable<Customer[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

      let headers = new HttpHeaders({
        'Authorization': 'Bearer ' + this.getToken()
      });

    return this.http.get<Customer[]>(this.SaleCustomerUrl, { params, headers });
  }

  fetchOrders(): Observable<Order> {
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

    return this.http.get<Order>(this.AdminOrderUrl, { headers });
  }
}
