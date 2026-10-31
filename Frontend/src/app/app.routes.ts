import { Routes } from '@angular/router';
import { HomePage } from './pages/home/home.page';
import { CarPage } from './pages/car/car.page';
import { AdminPage } from './pages/admin/admin.page';
import { AdminLoginPage } from './pages/admin-login/admin-login.page';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomePage },
    { path: 'car', component: CarPage },
    { path: 'admin', component: AdminPage },
    { path: 'admin-login', component: AdminLoginPage }
];
