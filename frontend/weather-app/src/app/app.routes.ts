import { Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login';
import { WeatherComponent } from './features/weather/weather/weather';
import { AuthGuard } from './core/guards/auth-guard';
import { RegisterComponent } from './features/auth/register/register';
export const routes: Routes = [
    {path:'',component:LoginComponent},
    {path:'register',component:RegisterComponent},
    {
        path:'weather',
        loadComponent:()=>import('./features/weather/weather/weather')
        .then(m=>m.WeatherComponent),
        canActivate:[AuthGuard]
    }
];
