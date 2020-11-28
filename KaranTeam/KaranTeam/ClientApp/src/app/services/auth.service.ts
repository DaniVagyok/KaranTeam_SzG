import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user.model';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // ***********************************
  // MODIFY
  // ***********************************

  private baseUrl = ''; // environment.baseUrl;
  private tokenString = 'token';
  constructor(private http: HttpClient,
              private router: Router) { }

  loginUser(user: User): any {
    const url = this.baseUrl + 'api/auth/login';
    return this.http.post<any>(url, user);
    /*return this.http.post<any>(url, user).pipe(
      tap(res => this.setLocalToken(res))
    );*/
  }

  loggedIn(){
    return !!localStorage.getItem('token')
  }

  registerUser(user: User): any {
    const url = this.baseUrl + 'api/auth/register';
    this.router.navigate(['/login']);
    return this.http.post<any>(url, user);
  }

  logoutUser() {
    const url = this.baseUrl + 'api/auth/logout';
    this.router.navigate(['/']);
    localStorage.removeItem('token');
    return this.http.post<any>(url, null).pipe(
      // Ez valamiért nem törölte a tokent
      //tap(() => this.removeLocalToke())
    );
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
