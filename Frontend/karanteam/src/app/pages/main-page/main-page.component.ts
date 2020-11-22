import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { MainPageService } from 'src/app/services/main-page.service';
import { IShopItemModel } from 'src/app/shared/models/shop-item.model';

@Component({
  selector: 'karanteam-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  subscriptions: Subscription[];
  shopItems: IShopItemModel[] = [];
  searchForm: FormGroup = new FormGroup({
    searchValue: new FormControl('')
  });

  constructor(
    private service: MainPageService
  ) { }

  ngOnInit(): void {
    this.service.getShopItems().subscribe(res => this.shopItems = res);
  }

}
