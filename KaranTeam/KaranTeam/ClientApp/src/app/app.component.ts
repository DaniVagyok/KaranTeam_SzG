import { Component } from '@angular/core';
import { AuthService } from "./services/auth.service";

@Component({
  selector: 'karanteam-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'karanteam';

  constructor(public authService:AuthService){}
}
