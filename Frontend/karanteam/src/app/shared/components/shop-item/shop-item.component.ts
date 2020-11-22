import { Component, Input, OnInit } from '@angular/core';
import { IShopItemModel } from '../../models/shop-item.model';

@Component({
  selector: 'karanteam-shop-item',
  templateUrl: './shop-item.component.html',
  styleUrls: ['./shop-item.component.scss']
})
export class ShopItemComponent implements OnInit {
  @Input() shopItem: IShopItemModel;
  constructor() { }

  ngOnInit(): void {
  }

}
