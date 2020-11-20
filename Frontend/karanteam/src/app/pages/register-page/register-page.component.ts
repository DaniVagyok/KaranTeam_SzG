import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'karanteam-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})

export class RegisterPageComponent implements OnInit {

  registerUserData : any = {}

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
  }

  registerUser(){
    this.auth.registerUser(this.registerUserData)
    .subscribe( 
      res => console.log(res),
      err => console.log(err)
    )
  }

}
