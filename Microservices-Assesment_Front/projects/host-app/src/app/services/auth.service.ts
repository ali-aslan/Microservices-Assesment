import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {Observable, catchError, map, of, throwError} from "rxjs";
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router,private http: HttpClient ) { }

  setToken(token: string) {
    localStorage.setItem('token', token)
  }

  setRole(role: string) {
    localStorage.setItem('role', role)
  }

  getRole() {
    return localStorage.getItem('role')
  }
  removeRole() {
    return localStorage.removeItem('role')
  }


  getToken() {
    return localStorage.getItem('token')
  }

  removeToken(){
    localStorage.removeItem('token')
  }

  isLoggedIn() {
    return this.getToken() !== null;
  }

  login(userInfo: { email: string, password: string }): Observable<string | boolean> {
    return this.http.post<any>(`https://localhost:44387/api/Auth/Login`, {
      email: userInfo.email,
      password: userInfo.password,
      authenticatorCode: "string"
    }).pipe(
      map(response => {
        if (response && response.accessToken  && response.accessToken.token) {
          this.setToken(response.accessToken.token);
         const roles = this.getUserRole(response.accessToken.token);
         console.log(roles);


     
          return true;

        } else {
          throwError(() => new Error(response.detail))
          return false; 
        }
      }),
    );
  }

  getUserRole(token:string){
    const helper = new JwtHelperService();
    const decodedToken = helper.decodeToken(token);
    if(decodedToken){
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    this.setRole(role);
    return role; 
    }
    return "";
  }

  logout() {
    this.router.navigate(['login'])
    this.removeToken()
    this.removeRole()
  }
}
