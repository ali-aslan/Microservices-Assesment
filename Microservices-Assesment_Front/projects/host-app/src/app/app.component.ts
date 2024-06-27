import { Component } from '@angular/core';
import {filter, map, merge, Observable} from "rxjs";
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public UserRole: any = ''; 
  isLoading!: Observable<boolean>

  constructor(private authService: AuthService) {
    this.UserRole=this.authService.getRole()
    console.log(this.UserRole)
  }

  logout() {
    this.authService.logout()
    this.UserRole = undefined;
  }
}

