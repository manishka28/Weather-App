import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule, CommonModule],
  templateUrl: './login.html'
})
export class LoginComponent {

  username: string = '';
  password: string = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  login() {

    const data = {
      username: this.username,
      password: this.password
    };

    this.authService.login(data).subscribe({
      next: (res: any) => {

        console.log("Login Success", res);

        // if backend returns token directly
        this.authService.saveToken(res.token || res);

        this.router.navigate(['/weather']);
      },
      error: (err) => {
        console.log("Login Failed", err);
        alert("Invalid credentials");
      }
    });
  }
}