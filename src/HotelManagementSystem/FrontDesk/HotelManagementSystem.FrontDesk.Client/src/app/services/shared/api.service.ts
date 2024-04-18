import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://172.190.104.34:5005';

  constructor(private http: HttpClient, private matSnackBar: MatSnackBar) { }

  // Generic method to handle HTTP GET requests
  get<T>(path: string): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}/${path}`).pipe(
      catchError(this.handleError)
    );
  }

  // Generic method to handle HTTP POST requests
  post<T>(path: string, data: any): Observable<T> {
    var url = `${this.apiUrl}/${path}`
    if(path.startsWith('http'))
      url = path;
    return this.http.post<T>(url, data, this.getRequestOptions()).pipe(
      catchError(this.handleError)
    );
  }

  // Generic method to handle HTTP PUT requests
  put<T>(path: string, data: any): Observable<T> {
    return this.http.put<T>(`${this.apiUrl}/${path}`, data, this.getRequestOptions()).pipe(
      catchError(this.handleError)
    );
  }

  // Generic method to handle HTTP DELETE requests
  delete<T>(path: string): Observable<T> {
    return this.http.delete<T>(`${this.apiUrl}/${path}`, this.getRequestOptions()).pipe(
      catchError(this.handleError)
    );
  }

  // Helper method to construct request options (headers, etc.)
  private getRequestOptions() {
    // You can add any headers or authentication tokens here
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      // Add any additional headers here
    });
    return { headers };
  }

  // Helper method to handle errors
  private handleError(error: any) {
    if (error.error instanceof ErrorEvent) 
    {
      console.error('Client-side error:', error.error.message);
    } 
    else 
    {
      console.error('Server-side error:', error.status, error.error);
    }
    return throwError(() => error);
  }
}
