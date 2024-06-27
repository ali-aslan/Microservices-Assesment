import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home.component';
import { loadRemoteModule } from '@angular-architects/module-federation';
import { NotFoundComponent } from '../not-found/not-found.component';
import { AuthGuard } from '../guards/auth.guard';

const MFE_APP_URL = "http://localhost:4300/remoteEntry.js";
const SALE_APP_URL = "http://localhost:4400/SaleEntry.js";
const ADMIN_APP_URL = "http://localhost:4500/AdminEntry.js";
const DEALER_APP_URL = "http://localhost:4600/DealerEntry.js";

const routes: Routes = [
  {
    path: 'sale-panel', 
    canActivate: [AuthGuard], 
    loadChildren: () => loadRemoteModule({
      remoteEntry: MFE_APP_URL,
      remoteName: "mfeApp",
      exposedModule: "./TodoListModule"
    }).then(m => m.TodoListModule).catch(err => console.log(err))
  },
  {
    path: 'todo-list', 
    // canActivate: [AuthGuard], 
    loadChildren: () => loadRemoteModule({
      remoteEntry: SALE_APP_URL,
      remoteName: "saleApp",
      exposedModule: "./SalePanelModule"
    }).then(m => m.SalePanelModule).catch(err => console.log(err))
  },
  {
    path: 'admin-panel', 
    // canActivate: [AuthGuard], 
    loadChildren: () => loadRemoteModule({
      remoteEntry: ADMIN_APP_URL,
      remoteName: "adminApp",
      exposedModule: "./AdminPanelModule"
    }).then(m => m.AdminPanelModule).catch(err => console.log(err))
  },
  {
    path: 'dealer-panel', 
    // canActivate: [AuthGuard], 
    loadChildren: () => loadRemoteModule({
      remoteEntry: DEALER_APP_URL,
      remoteName: "dealerApp",
      exposedModule: "./DealerPanelModule"
    }).then(m => m.DealerPanelModule).catch(err => console.log(err))
  },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
