import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './pages/login/login.component';
import { LogoutComponent } from './pages/logout/logout.component';
import { LoginCompletedComponent } from './pages/login-completed/login-completed.component';
import { LogoutCompletedComponent } from './pages/logout-completed/logout-completed.component';
import { isAuthGuard } from './oauth/oauth.guard';

import { PageComponent } from './pages/protected/page/page.component';
import { HomeComponent } from './pages/protected/home/home.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'home',},

  {path: 'login', component: LoginComponent},
  {path: 'login-completed', component: LoginCompletedComponent},
  {path: 'logout', component: LogoutComponent},
  {path: 'logout-completed', component: LogoutCompletedComponent},

  {
    path: '',
    component: PageComponent,
    canActivate: [isAuthGuard],
    children: [
      {path: 'home', component: HomeComponent},
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
