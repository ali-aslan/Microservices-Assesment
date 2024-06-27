import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalePanelComponent } from './sale-panel.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    SalePanelComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpClientModule, 
    BrowserModule,
    BrowserAnimationsModule,

    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatGridListModule,
    RouterModule.forChild([
      {
        path: '',
        component: SalePanelComponent
      }
    ])
  ]
})
export class SalePanelModule { }
