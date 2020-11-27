import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  baseUrl = environment.baseUrl;
  constructor() { }


  getUserData() {
    return of(mock)
  }
}

const mock: User = {
  username: 'dzsudzsák',
  email: 'a@EMAIL.com',
  password: 'a',
}