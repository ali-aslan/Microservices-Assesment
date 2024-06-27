import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DealerPanelComponent } from './dealer-panel.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [DealerPanelComponent],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule, 
    RouterModule.forChild([
      {
        path: '',
        component: DealerPanelComponent
      }
    ])
  ]
})
export class DealerPanelModule { }
