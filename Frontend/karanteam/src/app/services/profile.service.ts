import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { User } from '../shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor() { }


  getUserData(){
    return of(mock)
  }
}

const mock : User = {
  username : 'dzsudzsák',
  email: 'a@EMAIL.com',
  password : 'a',
  token: 'nincstoken'
}