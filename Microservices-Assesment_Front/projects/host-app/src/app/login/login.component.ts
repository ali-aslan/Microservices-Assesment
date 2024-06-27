import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../services/auth.service";
import {Router} from "@angular/router";


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm!: FormGroup

  constructor(private router: Router,private authService: AuthService) {
  }


  submitLogin() {
    this.authService.login(this.loginForm.value).subscribe({
      next: () => {
        const role = this.authService.getRole()
        this.router.navigate(['home/'+role?.toLocaleLowerCase()+"-panel"])
      },
      error: (err) => alert(err.message)
    })
    console.log(this.loginForm.value)
  }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      'email': new FormControl('', [Validators.required, Validators.email]),
      'password': new FormControl('', [Validators.required, // Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{3,}$/)
      ])
    })
    if(this.authService.isLoggedIn()){
      const role = this.authService.getRole()
      this.router.navigate(['home/'+role?.toLocaleLowerCase()+"-panel"])
    }
  }
}


