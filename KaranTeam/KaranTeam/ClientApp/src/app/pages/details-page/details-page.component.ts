import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MainPageService } from 'src/app/services/main-page.service';
import { ProfileService } from 'src/app/services/profile.service';
import { IShopItemModel } from 'src/app/shared/models/shop-item.model';
import { User } from 'src/app/shared/models/user.model';

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
  commentToAdd: string;
  userData: User;
  constructor(
    private activatedRoute: ActivatedRoute,
    private service: MainPageService,
    private profileService: ProfileService
  ) { }

  ngOnInit(): void {
    this.shopItemId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.profileService.getUserData().subscribe(res => this.userData = res);
    this.service.getShopItemById(this.shopItemId).subscribe(res => {
      this.shopItem = res;
      this.thumbnailUri = `api/caff/${this.shopItem.id}/thumbnail`;
    },
    error => console.log(error),
    () => this.isLoading = false);
  }

  downloadImage() {
    this.service.downloadCiffCaffFile(this.shopItemId);
  }

  addComment(){
    this.service.addComment(this.commentToAdd, this.shopItem);
    this.commentToAdd='';
  }

}
