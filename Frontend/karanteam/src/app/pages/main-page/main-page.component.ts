import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';

@Component({
  selector: 'karanteam-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  subscriptions: Subscription[];
  searchForm: FormGroup = new FormGroup({
    searchValue: new FormControl('')
  });

  constructor() { }

  ngOnInit(): void {

  }

}
