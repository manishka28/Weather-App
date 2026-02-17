import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'http://localhost:5039/api/Auth';

  constructor(
    private http: HttpClient,
    private cookieService: CookieService
  ) {}

  login(data: any) {
    return this.http.post(`${this.apiUrl}/login`, data);
  }

  // ✅ Save token in cookie
  saveToken(token: string) {
    this.cookieService.set(
      'auth_token',
      token,
      1,            // expires in 1 day
      '/',
      '',
      true,         // secure (HTTPS only)
      'Strict'      // SameSite
    );
  }

  // ✅ Get token
  getToken(): string {
    return this.cookieService.get('auth_token');
  }

  // ✅ Check if logged in
  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  logout() {
    this.cookieService.delete('auth_token');
  }
}