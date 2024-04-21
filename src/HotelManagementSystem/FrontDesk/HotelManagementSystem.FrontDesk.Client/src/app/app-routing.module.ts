import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './pages/login/login.component';
import { LogoutComponent } from './pages/logout/logout.component';
import { LoginCompletedComponent } from './pages/login-completed/login-completed.component';
import { LogoutCompletedComponent } from './pages/logout-completed/logout-completed.component';
import { isAuthGuard } from './oauth/oauth.guard';

import { HomeComponent } from './pages/protected/home/home.component';
import { BookingDetailsComponent } from './pages/protected/booking-details/booking-details.component';
import { HeaderComponent } from './pages/protected/header/header.component';
import { RoomComponent } from './pages/protected/room/room.component';
import { BookingRegisterComponent } from './pages/protected/booking-register/booking-register.component';
import { BookingsComponent } from './pages/protected/bookings/bookings.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'all-bookings',},

  {path: 'login', component: LoginComponent},
  {path: 'login-completed', component: LoginCompletedComponent},
  {path: 'logout', component: LogoutComponent},
  {path: 'logout-completed', component: LogoutCompletedComponent},

  {
    path: '',
    component: HeaderComponent,
    canActivate: [isAuthGuard],
    children: [
      {path: 'home', component: HomeComponent},
      {path: 'booking-details/:id', component: BookingDetailsComponent},
      {path: 'room', component: RoomComponent},
      {path: 'booking-register', component: BookingRegisterComponent},
      {path: 'all-bookings', component: BookingsComponent}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
