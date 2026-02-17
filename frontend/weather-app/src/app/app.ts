import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet,HttpClientModule,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css',
  providers:[
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ]
})
export class App {
  protected readonly title = signal('weather-app');
}
