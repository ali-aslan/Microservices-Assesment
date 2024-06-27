import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SalePanelComponent } from './sale-panel/sale-panel.component';

const routes: Routes = [
  {path:'',redirectTo:'/sale-panel',pathMatch:'full'},
  {path:'sale-panel',component:SalePanelComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
