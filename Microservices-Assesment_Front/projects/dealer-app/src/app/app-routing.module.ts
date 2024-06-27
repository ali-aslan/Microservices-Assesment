import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DealerPanelComponent } from './dealer-panel/dealer-panel.component';

const routes: Routes = [
  {path:"",redirectTo:"/dealer-panel",pathMatch:"full"},
  {path:"dealer-panel",component:DealerPanelComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
