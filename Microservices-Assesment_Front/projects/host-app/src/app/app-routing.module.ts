import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { loadRemoteModule } from '@angular-architects/module-federation';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';

import {AuthGuard} from "./guards/auth.guard";


const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule), component: HomeComponent, canActivate: [AuthGuard]},
  { path: '**', component: NotFoundComponent },
];


@NgModule({
  imports: [RouterModule.forRoot(routes,{ onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

// export const routeCompArr = [HomeComponent];
export const routeCompArr = [];