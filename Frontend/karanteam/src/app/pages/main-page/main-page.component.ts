import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { MainPageService } from 'src/app/services/main-page.service';
import { IShopItemModel } from 'src/app/shared/models/shop-item.model';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UploaderComponent } from './components/uploader/uploader.component';

@Component({
  selector: 'karanteam-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  subscriptions: Subscription[];
  shopItems: IShopItemModel[] = [];
  searchedItems: IShopItemModel[] = [];
  searchForm: FormGroup = new FormGroup({
    searchValue: new FormControl('')
  });

  constructor(
    private service: MainPageService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.service.getShopItems().subscribe(res => {
      this.shopItems = res;
      this.searchedItems = res;
    });
    this.searchForm.controls.searchValue.valueChanges.subscribe(res =>
      this.searchedItems = this.shopItems.filter(x => x.title.includes(res))
    );
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(UploaderComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => this.service.uploadShopItem(result));
  }

}
