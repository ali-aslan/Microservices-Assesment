import { Injectable } from '@angular/core';
import { Shipper, Supplier } from './dealer-panel/dealer-panel.component';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DealerServiceService {

  private DealerShipperUrl = 'https://localhost:44387/api/Shipper';
  private DealerSupplierUrl = 'https://localhost:44387/api/Supplier';

  constructor(private http: HttpClient) { }

  getToken() {
    return localStorage.getItem('token')
  }


  //#region Supplier

  addSupplier(supplier: Supplier): Observable<Supplier> {

    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });
    
    return this.http.post<Supplier>(this.DealerSupplierUrl, supplier, { headers });
  }

  getSuppliers(pageIndex: number, pageSize: number): Observable<Supplier[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

      
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

      return this.http.get<Supplier[]>(this.DealerSupplierUrl, { params, headers });
  }

  getSupplierById(id: string): Observable<Supplier[]> {
    
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

    return this.http.get<Supplier[]>(`${this.DealerSupplierUrl}/${id}`, { headers });
  }
  //#endregion


  //#region Shipper

  addShipper(Shipper: Shipper): Observable<Shipper> {
    
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });
    return this.http.post<Shipper>(this.DealerShipperUrl, Shipper , { headers });
  }

  getShippers(pageIndex: number, pageSize: number): Observable<Shipper[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

      
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });

      return this.http.get<Shipper[]>(this.DealerShipperUrl, { params,headers });
  }

  getShipperById(id: string): Observable<Shipper[]> {
    
    let headers = new HttpHeaders({
      'Authorization': 'Bearer ' + this.getToken()
    });
    return this.http.get<Shipper[]>(`${this.DealerShipperUrl}/${id}`, { headers });
  }
  //#endregion
}
