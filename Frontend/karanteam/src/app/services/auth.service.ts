import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user.model';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // ***********************************
  // MODIFY
  // ***********************************

  private baseUrl = environment.baseUrl;
  private tokenString = 'token';
  constructor(private http: HttpClient) { }

  loginUser(user: User): any {
    const url = this.baseUrl + 'api/auth/login';
    return this.http.post<any>(url, user).pipe(
      tap(res => this.setLocalToken(res.token))
    );
  }

  registerUser(user: User): any {
    const url = this.baseUrl + 'api/auth/register';
    return this.http.post<any>(url, user);
  }

  setLocalToken(token: string): void {
    localStorage.setItem(this.tokenString, token);
  }

  removeLocalToke(): void {
    localStorage.removeItem(this.tokenString);
  }

  getLocalToken(): string {
    return localStorage.getItem(this.tokenString);
  }
}
