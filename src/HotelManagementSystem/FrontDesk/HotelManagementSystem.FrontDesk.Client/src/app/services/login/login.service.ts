import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../shared/http/api.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private apiService: ApiService) { }

  // Method to perform login
  login(loginInfo: any): Observable<any> {
    // Replace 'login-endpoint' with your actual login endpoint
    return this.apiService.post<any>('http://172.190.104.34:5003/login', loginInfo);
  }

  // Method to perform logout
  logout(): Observable<any> {
    // Replace 'logout-endpoint' with your actual logout endpoint
    return this.apiService.post<any>('logout-endpoint', {});
  }

  // Method to check if user is logged in
  isLoggedIn(): boolean {
    // Check if user is logged in based on session or token
    // You can implement your own logic here based on your authentication mechanism
    return true; // For demonstration purposes, always return true
  }
}