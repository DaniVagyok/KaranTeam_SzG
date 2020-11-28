import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user.model';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private tokenString = 'token';
  baseUrl = ''; // environment.baseUrl;
  constructor(
    private http: HttpClient
  ) { }

  /***************
   UserController
   ****************/
  // Elméletileg kész
  getUserData(): Observable<User> {
    const userId = jwt_decode(this.getLocalToken())['id'];
    const url = this.baseUrl + `api/user/${userId}`;
    return this.http.get<User>(url);

    // Ez csak tesztelés miatt van benne. Ki lehet szedni ha megy minden
    return of(mock);
  }

  // Elméletileg kész
  modifyUserData(user: User): Observable<void> {
    const url = this.baseUrl + `api/user/${user.id}`;
    return this.http.put<any>(url, user);

    // Ez csak tesztelés miatt van benne. Ki lehet szedni ha megy minden
    return of();
  }

  getLocalToken(): string {
    return localStorage.getItem(this.tokenString);
  }
}

const mock: User = {
  id: 1,
  username: 'dzsudzsák',
  email: 'a@EMAIL.com',
  password: 'a',
};
