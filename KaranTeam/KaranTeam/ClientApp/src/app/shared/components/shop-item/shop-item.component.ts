import { Component, Input, OnInit } from '@angular/core';
import { from, fromEventPattern } from 'rxjs';
import { MainPageService } from 'src/app/services/main-page.service';
import { IShopItemModel } from '../../models/shop-item.model';

@Component({
  selector: 'karanteam-shop-item',
  templateUrl: './shop-item.component.html',
  styleUrls: ['./shop-item.component.scss']
})
export class ShopItemComponent implements OnInit {
  @Input() shopItem: IShopItemModel;
  thumbnailUri: string;
  constructor(
    private service: MainPageService,
  ) { }

  ngOnInit(): void {
    this.thumbnailUri = `api/caff/${this.shopItem.id}/thumbnail`;
  }

  downloadImage(): void {
    this.service.downloadCiffCaffFile(this.shopItem.id).subscribe(res => {
      let url = window.URL.createObjectURL(res);
      let a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = this.shopItem.title + '.caff';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    });
  }
}
