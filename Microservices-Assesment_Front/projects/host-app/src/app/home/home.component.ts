import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Router, NavigationEnd } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  public UserRole: any = 'Admin'; 
  isLoading!: Observable<boolean>

  constructor(private authService: AuthService) {
    this.UserRole=this.authService.getRole()
    console.log(this.UserRole)
  }

  logout() {
    this.authService.logout()
  }
}

