import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AdminPanelComponent } from './admin-panel.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    AdminPanelComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule, 
    RouterModule.forChild([
      {
        path: '',
        component: AdminPanelComponent
      }
    ])
  ]
})
export class AdminPanelModule { }
