import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import * as L from 'leaflet';

@Component({
  selector: 'app-weather',
  standalone: true,
  imports: [FormsModule, HttpClientModule, CommonModule],
  templateUrl: './weather.html'
})
export class WeatherComponent {
  city: string = '';
  weather: any;
  map: any; // store Leaflet map instance

  constructor(private http: HttpClient) {}

  search() {
    if (!this.city.trim()) return; // prevent empty search

    const apiKey = '15ece297412d5c0b60198145bd21aac5';
    this.http.get(
      `https://api.openweathermap.org/data/2.5/weather?q=${this.city}&appid=${apiKey}&units=metric`
    ).subscribe({
      next: (data: any) => {
        this.weather = data;
        console.log(this.weather);

        if (this.weather?.coord) {
          this.initMap(this.weather.coord.lat, this.weather.coord.lon);
        }
      },
      error: (err) => {
        console.error('Error fetching weather', err);
        alert('City not found or API error!');
      }
    });
  }

  initMap(lat: number, lon: number) {
    // If map exists, just reset view
    if (this.map) {
      this.map.setView([lat, lon], 12);
      return;
    }

    // Create map
    this.map = L.map('map').setView([lat, lon], 12);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap contributors'
    }).addTo(this.map);

    L.marker([lat, lon]).addTo(this.map)
      .bindPopup(`${this.weather.name}, ${this.weather.sys.country}`)
      .openPopup();
  }
}