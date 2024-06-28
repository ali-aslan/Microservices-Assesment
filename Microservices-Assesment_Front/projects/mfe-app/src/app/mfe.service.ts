import { Injectable } from '@angular/core';
import { Customer, Order, Product } from './todo-list/todo-list.component';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MfeService {

  private SaleCustomerUrl = 'https://localhost:44387/api/Customer';
  private SaleProductUrl = 'https://localhost:44387/api/Product';
  private SaleOrderUrl = 'https://localhost:44387/api/Order';

  constructor(private http: HttpClient) { }

  getToken() {
    return localStorage.getItem('token')
  }

  //#region Customer
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


    return this.http.get<Customer[]>(this.SaleCustomerUrl, { params,headers });
  }

  deleteCustomerById(id: string): Observable<any> {

    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

    return this.http.delete(`${this.SaleCustomerUrl}/${id}`, { headers });
  }
  //#endregion


  //#region Product
  addProduct(product: Product): Observable<Product> {
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

    return this.http.post<Product>(this.SaleProductUrl, product, { headers });
  }

  getProducts(pageIndex: number, pageSize: number): Observable<Product[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

      let headers = new HttpHeaders({
        'Authorization': 'Bearer ' + this.getToken()
      });


      return this.http.get<Product[]>(this.SaleProductUrl, { params,headers });
  }

  deleteProductById(id: string): Observable<any> {
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

    
    return this.http.delete(`${this.SaleProductUrl}/${id}`, { headers });
  }
  //#endregion


 //#region Order
 addOrder(order: Order): Observable<Order> {

  let headers = new HttpHeaders({
    'Authorization': 'Bearer ' + this.getToken()
  });

  
  return this.http.post<Order>(this.SaleOrderUrl, order , { headers });
}

getOrders(pageIndex: number, pageSize: number): Observable<Order[]> {
  let params = new HttpParams()
    .set('PageIndex', pageIndex.toString())
    .set('PageSize', pageSize.toString());

    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

    return this.http.get<Order[]>(this.SaleOrderUrl, { params,headers });
}

getOrderByCustomerId(id: string): Observable<Order[]> {
  let headers = new HttpHeaders({
    'Authorization': 'Bearer ' + this.getToken()
  });

  return this.http.get<Order[]>(`${this.SaleOrderUrl}/Customer/${id}` , { headers });
}
//#endregion
}
