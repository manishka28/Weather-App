import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, HttpClientModule, CommonModule],
  templateUrl: './register.html'
})
export class RegisterComponent {

  username: string = '';
  email: string = '';
  password: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  register() {
    const data = {
      Username: this.username,
      Email: this.email,
      Password: this.password
    };

    this.http.post('http://localhost:5039/api/Auth/register', data,{responseType:'text'})
      .subscribe({
        next: (res) => {
          alert('Registration successful!');
          this.router.navigate(['/']); // Redirect to login
        },
        error: (err) => {
          console.error(err);
          alert('Registration failed. Check console.');
        }
      });
  }
}