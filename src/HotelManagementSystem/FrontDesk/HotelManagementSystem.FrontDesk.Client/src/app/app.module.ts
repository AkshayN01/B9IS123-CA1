import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppConfig, initConfig } from './app.config';

import { OAuthModule } from 'angular-oauth2-oidc';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';

import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { NgxSpinnerModule } from "ngx-spinner";
import { MaterialModule } from './material/material.module';
import { LoginComponent } from './pages/login/login.component';
import { LogoutComponent } from './pages/logout/logout.component';
import { LoginCompletedComponent } from './pages/login-completed/login-completed.component';
import { LogoutCompletedComponent } from './pages/logout-completed/logout-completed.component';
import { HomeComponent } from './pages/protected/home/home.component';
import { PageComponent } from './pages/protected/page/page.component';
import { BookingDetailsComponent } from './pages/protected/booking-details/booking-details.component';
import { LayoutComponent } from './pages/protected/Layout/layout.component';
import { ReasonModalComponent } from './pages/reason-modal/reason-modal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './pages/protected/header/header.component';
import { RoomComponent } from './pages/protected/room/room.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LogoutComponent,
    LoginCompletedComponent,
    LogoutCompletedComponent,
    HomeComponent,
    PageComponent,
    LayoutComponent,
    ReasonModalComponent,
    BookingDetailsComponent,
    HeaderComponent,
    RoomComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MaterialModule,
    AppRoutingModule,
    MatDialogModule,
    ReactiveFormsModule,
    FormsModule,
    OAuthModule.forRoot({
      resourceServer: {
        allowedUrls: ['/'],
        sendAccessToken: true
      }
    }),
    NgxSpinnerModule
  ],
  providers: [
    AppConfig,
    {
      provide: APP_INITIALIZER,
      useFactory: initConfig,
      deps: [AppConfig],
      multi: true
    },
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
