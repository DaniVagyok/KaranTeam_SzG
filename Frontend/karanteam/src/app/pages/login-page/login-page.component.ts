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

  constructor(
    private auth: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  loginUser(): void {
    // TODO: ezt a sort majd átrakni a subscribe-ba
    // this.router.navigate(['/main']);
    this.auth.loginUser(this.loginUserData)
      .subscribe(res => {
        console.log('Login res', res);
      },
        err => console.log(err)
      );
  }

}
