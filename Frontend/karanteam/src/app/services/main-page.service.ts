import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { IShopItemModel } from '../shared/models/shop-item.model';

@Injectable({
  providedIn: 'root'
})
export class MainPageService {

  constructor() { }

  getShopItems(): Observable<IShopItemModel[]> {
    return of(mock);
  }
}

const mock: IShopItemModel[] = [
  {
    id: 1,
    title: 'Title 1'
  },
  {
    id: 2,
    title: 'Title 2'
  },
  {
    id: 3,
    title: 'Title 3'
  }
];