import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpRequest, HttpHandler } from '@angular/common/http';

import { AuthService } from './auth.service';
import { Observable } from 'rxjs/internal/Observable';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    
  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    const authRequest = request.clone({
        setHeaders: {
        Authorization: `Bearer ${this.authService.getToken()}`
    }
    });
    return next.handle(authRequest);
  }

}