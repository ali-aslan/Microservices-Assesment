import { ChangeDetectorRef, Component } from '@angular/core';
import { DealerServiceService } from '../dealer-service.service';


export interface Shipper {
  id: string;
  name: string;
  phone: string;
}

export interface Supplier {
  id: string;
  name: string;
  contactName: string;
  phone: string;
}

@Component({
  selector: 'app-dealer-panel',
  templateUrl: './dealer-panel.component.html',
  styleUrls: ['./dealer-panel.component.scss']
})
export class DealerPanelComponent {

    
    constructor(private cdr: ChangeDetectorRef,private dealerService : DealerServiceService) {  }

    //#region Shipper
    shipper: Shipper = { id: '', name: '', phone: ''};
    shipperPageData: any ;
    shipperGetById = {shipperID: ''} ;
    shipperById:  any ;

    ShipperSubmit(shipper: Shipper) {
    this.dealerService.addShipper(shipper).subscribe(
      (response) => {
        alert('Shipper added successfully');
      },
      (error) => {
        alert('Shipper not added.'+ error.error);
      }
    );
    this.shipper = { id: '', name: '', phone: ''};
    this.cdr.detectChanges();
  }

  getShippers() { 
    this.dealerService.getShippers(0, 10).subscribe(
    (data) => {
      this.shipperPageData = data;
      alert('Shipper List get successfully!');
    },
    (error) => {
      alert('Shipper List not get.'+ error.error);
    }
  );
  }

  getShipperById(id:string) {
    this.dealerService.getShipperById(id).subscribe(
      (data) => {
        this.shipperById = data;
        alert('Shipper  get successfully!');
      },
      (error) => {
        alert('Shipper not get.'+ error.error);
      }
    );
  }

    //#endregion



        //#region Supplier
        supplier: Supplier = { id: '', name: '', phone: '',contactName: ''};
        supplierPageData: any ;
        supplierGetById = {supplierID: ''} ;
        supplierById:  any ;
    
        SupplierSubmit(supplier: Supplier) {
        this.dealerService.addSupplier(supplier).subscribe(
          (response) => {
            alert('Supplier added successfully');
          },
          (error) => {
            alert('Supplier not added.'+ error.error);
          }
        );
        this.supplier = { id: '', name: '', phone: '',contactName: ''};
        this.cdr.detectChanges();
      }
    
      getSuppliers() { 
        this.dealerService.getSuppliers(0, 10).subscribe(
        (data) => {
          this.supplierPageData = data;
          alert('Supplier List get successfully!');
        },
        (error) => {
          alert('Supplier List not get.'+ error.error);
        }
      );
      }
    
      getSupplierById(id:string) {
        this.dealerService.getSupplierById(id).subscribe(
          (data) => {
            this.supplierById = data;
            alert('Supplier  get successfully!');
          },
          (error) => {
            alert('Supplier not get.'+ error.error);
          }
        );
      }
    
        //#endregion

    

    
  }


