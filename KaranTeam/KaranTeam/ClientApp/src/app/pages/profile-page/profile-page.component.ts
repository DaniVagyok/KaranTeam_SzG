import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ProfileService } from 'src/app/services/profile.service';

import { User } from "../../shared/models/user.model";

@Component({
  selector: 'karanteam-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {

  userData: User;
  modifyForm;

  constructor(
    private profileService: ProfileService,
    private formBuilder: FormBuilder
  ) {
    this.modifyForm = this.formBuilder.group({
      username: '',
      email: '',
      password: ''
    })
  }

  ngOnInit(): void {
    this.profileService.getUserData().subscribe(res => this.userData = res);
  }

  onSubmit() {
    if (this.modifyForm.value.username) {
      this.userData.userName = this.modifyForm.value.username;
    }
    if (this.modifyForm.value.email) {
      this.userData.email = this.modifyForm.value.email;
    }
    if (this.modifyForm.value.password) {
      this.userData.password = this.modifyForm.value.password;
    }
    if (this.modifyForm.value.username || this.modifyForm.value.email || this.modifyForm.value.password) {
      this.profileService
      .modifyUserData({id: this.userData.id,
        email: this.userData.email,
        userName: this.userData.userName,
        isAdmin: this.userData.isAdmin,
        password: this.userData.password}).subscribe();
    }
  }

}
