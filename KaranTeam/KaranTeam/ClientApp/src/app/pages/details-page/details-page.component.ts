import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MainPageService } from 'src/app/services/main-page.service';
import { IShopItemModel } from 'src/app/shared/models/shop-item.model';

@Component({
  selector: 'karanteam-details-page',
  templateUrl: './details-page.component.html',
  styleUrls: ['./details-page.component.scss']
})
export class DetailsPageComponent implements OnInit {
  shopItem: IShopItemModel;
  thumbnailUri: string;
  shopItemId: number;
  isLoading: boolean = true;
  constructor(
    private activatedRoute: ActivatedRoute,
    private service: MainPageService
  ) { }

  ngOnInit(): void {
    this.shopItemId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.service.getShopItemById(this.shopItemId).subscribe(res => {
      this.shopItem = res;
      this.thumbnailUri = `api/caff/${this.shopItem.id}/thumbnail`;
    },
    error => console.log(error),
    () => this.isLoading = false);
  }

  downloadImage(): void {
    // TODO: implement
  }

}
