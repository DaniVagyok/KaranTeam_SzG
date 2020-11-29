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
  isAdmin: boolean;
  constructor(
    private activatedRoute: ActivatedRoute,
    private service: MainPageService,
    private profileService: ProfileService
  ) { }

  ngOnInit(): void {
    this.shopItemId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.profileService.getAdmin().subscribe(res => this.isAdmin = res);
    this.profileService.getUserData().subscribe(res => this.userData = res);
    this.loadData();
  }

  downloadImage() {
    this.service.downloadCiffCaffFile(this.shopItemId).subscribe(res => {
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

  addComment() {
    this.service.addComment(this.commentToAdd, this.shopItem.id).subscribe(() => {
      this.service.getShopItemById(this.shopItemId).subscribe(res => {
        this.shopItem = res;
      });
    });
    this.commentToAdd = '';
  }

  deleteComment(commentId: number) {
    this.service.deleteComment(commentId).subscribe(() => this.loadData());
  }

  loadData() {
    this.service.getShopItemById(this.shopItemId).subscribe(res => {
      this.shopItem = res;
      this.thumbnailUri = `api/caff/${this.shopItem.id}/thumbnail`;
    },
      error => console.log(error),
      () => this.isLoading = false);
  }
}
