import { Injectable } from '@angular/core';
import { Shipper, Supplier } from './dealer-panel/dealer-panel.component';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DealerServiceService {

  private DealerShipperUrl = 'https://localhost:44383/api/Shipper';
  private DealerSupplierUrl = 'https://localhost:44383/api/Supplier';

  constructor(private http: HttpClient) { }

  //#region Supplier

  addSupplier(supplier: Supplier): Observable<Supplier> {
    return this.http.post<Supplier>(this.DealerSupplierUrl, supplier);
  }

  getSuppliers(pageIndex: number, pageSize: number): Observable<Supplier[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

      return this.http.get<Supplier[]>(this.DealerSupplierUrl, { params });
  }

  getSupplierById(id: string): Observable<Supplier[]> {
    return this.http.get<Supplier[]>(`${this.DealerSupplierUrl}/${id}`);
  }
  //#endregion


  //#region Shipper

  addShipper(Shipper: Shipper): Observable<Shipper> {
    return this.http.post<Shipper>(this.DealerShipperUrl, Shipper);
  }

  getShippers(pageIndex: number, pageSize: number): Observable<Shipper[]> {
    let params = new HttpParams()
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

      return this.http.get<Shipper[]>(this.DealerShipperUrl, { params });
  }

  getShipperById(id: string): Observable<Shipper[]> {
    return this.http.get<Shipper[]>(`${this.DealerShipperUrl}/${id}`);
  }
  //#endregion
}
