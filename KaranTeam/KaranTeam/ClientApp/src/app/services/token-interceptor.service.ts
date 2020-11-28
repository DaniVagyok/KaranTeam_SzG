import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from 'rxjs';
import { AuthService } from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor{

  constructor(private injector: Injector) { }

  intercept(req, next) {
    let authService = this.injector.get(AuthService);
    console.log('itt');
    let tokenizedReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authService.getLocalToken()}`
      }
    });
    return next.handle(tokenizedReq);
  }
}
