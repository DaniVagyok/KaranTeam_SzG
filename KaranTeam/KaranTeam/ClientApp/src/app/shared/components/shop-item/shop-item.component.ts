import { Component, Input, OnInit } from '@angular/core';
import { from, fromEventPattern } from 'rxjs';
import { IShopItemModel } from '../../models/shop-item.model';

@Component({
  selector: 'karanteam-shop-item',
  templateUrl: './shop-item.component.html',
  styleUrls: ['./shop-item.component.scss']
})
export class ShopItemComponent implements OnInit {
  @Input() shopItem: IShopItemModel;
  thumbnailUri: string;
  constructor() { }

  ngOnInit(): void {
    this.thumbnailUri = `api/caff/${this.shopItem.id}/thumbnail`;
  }

  downloadImage(): void {
    // TODO: implement
  }
}
