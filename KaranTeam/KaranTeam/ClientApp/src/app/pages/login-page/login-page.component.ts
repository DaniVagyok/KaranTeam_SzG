import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'karanteam-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  loginUserData: any = {};
  private tokenString = 'token';

  constructor(
    private auth: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  loginUser(): void {
    this.auth.loginUser(this.loginUserData)
      .subscribe(res => {
        console.log('Login res', res);
        this.setLocalToken(res);
        //localStorage.setItem('token', res.token);
        this.router.navigate(['/main']);
      },
        err => console.log(err)
      );
  }

  setLocalToken(token: string): void {
    localStorage.setItem(this.tokenString, token);
  }

}
