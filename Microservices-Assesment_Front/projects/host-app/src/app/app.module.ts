import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';//login sayfasına giriş için

import { HttpClientModule} from "@angular/common/http";//request göndermek için


//Theme
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar'; 
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,

    BrowserAnimationsModule,  // Angular Material
    MatButtonModule,  // Angular Material
    MatCardModule,  // Angular Material
    MatToolbarModule, // Angular Material MatToolbarModule 
    MatProgressBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
