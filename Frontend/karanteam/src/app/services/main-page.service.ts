import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { IShopItemModel } from '../shared/models/shop-item.model';

@Injectable({
  providedIn: 'root'
})
export class MainPageService {

  constructor(
    private http: HttpClient
  ) { }

  getShopItems(): Observable<IShopItemModel[]> {
    return of(mock);
  }

  uploadShopItem(shopItem: IShopItemModel): Observable<void> {
    mock.push(shopItem);
    // TODO: URL-t átírni majd
    const url = 'localhost';
    const formData = new FormData();
    const shopItemDto = {
      ...shopItem
    };
    for (const key in shopItemDto) {
      if (key) {
        formData.append(key, shopItemDto[key]);
      }
    }
    this.http.post<any>(url, formData);
    return of(null);
  }
}

const mock: IShopItemModel[] = [
  {
    id: 1,
    title: 'Title 1',
    comments: [
      {
        id: 1,
        comment: 'ASDAD',
        date: new Date(),
        ownerName: 'Jóska'
      },
      {
        id: 1,
        comment: 'ASDAD',
        date: new Date(),
        ownerName: 'Jóska'
      }
    ],
    description: 'Description 1',
    ownerName: 'Béla',
    imageUrl: 'https://kep.cdn.indexvas.hu/1/0/3207/32070/320704/32070459_68db62359be24ab16b2103d76892be76_wm.jpg'
  },
  {
    id: 2,
    title: 'Title 2',
    comments: [
      {
        id: 1,
        comment: 'ASDAD',
        date: new Date(),
        ownerName: 'Jóska'
      },
      {
        id: 1,
        comment: 'ASDAD',
        date: new Date(),
        ownerName: 'Jóska'
      }
    ],
    description: 'Description 1',
    ownerName: 'Béla',
    imageUrl: 'https://kep.cdn.indexvas.hu/1/0/3207/32070/320704/32070459_68db62359be24ab16b2103d76892be76_wm.jpg'
  },
  {
    id: 3,
    title: 'Title 3',
    comments: [
      {
        id: 1,
        comment: 'ASDAD',
        date: new Date(),
        ownerName: 'Jóska'
      },
      {
        id: 1,
        comment: 'ASDAD',
        date: new Date(),
        ownerName: 'Jóska'
      }
    ],
    description: 'Description 1',
    ownerName: 'Béla',
    imageUrl: 'https://kep.cdn.indexvas.hu/1/0/3207/32070/320704/32070459_68db62359be24ab16b2103d76892be76_wm.jpg'
  },
];
