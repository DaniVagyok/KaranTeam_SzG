import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MainPageService } from 'src/app/services/main-page.service';
import { IShopItemModel } from 'src/app/shared/models/shop-item.model';

@Component({
  selector: 'karanteam-details-page',
  templateUrl: './details-page.component.html',
  styleUrls: ['./details-page.component.scss']
})
export class DetailsPageComponent implements OnInit {
  thumbnailUri: string;
  shopItemId: number;
  shopItem: IShopItemModel;
  constructor(
    private activatedRoute: ActivatedRoute,
    private service: MainPageService
  ) { }

  ngOnInit(): void {
    this.shopItemId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.service.getShopItemById(this.shopItemId).subscribe(res => {
      this.shopItem = res;
      this.thumbnailUri = `api/caff/${this.shopItem.id}/thumbnail`;
    });
  }

  downloadImage(): void {
    // TODO: implement
  }

}
