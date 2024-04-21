import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HeadersInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log(request)
    const secret = 'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols='
    const modifiedRequest = request.clone({
      setHeaders:{
        secret
      }
    })
    return next.handle(modifiedRequest);
  }
}