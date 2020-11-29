import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IShopItemModel } from '../shared/models/shop-item.model';

@Injectable({
  providedIn: 'root'
})
export class MainPageService {

  baseUrl = ''; //environment.baseUrl;
  constructor(
    private http: HttpClient
  ) { }

  /***************
  CiffCaffController
  ****************/
  // Elméletileg kész
  getShopItemsList(): Observable<IShopItemModel[]> {
    const url = this.baseUrl + 'api/caff';
    return this.http.get<IShopItemModel[]>(url);

    // Ez csak tesztelés miatt van benne. Ki lehet szedni ha megy minden
    return of(mock);
  }

  // Elméletileg kész
  getShopItemById(shopItemId: number): Observable<IShopItemModel> {
    const url = this.baseUrl + `api/caff/${shopItemId}`;
    return this.http.get<IShopItemModel>(url);

    // Ez csak tesztelés miatt van benne. Ki lehet szedni ha megy minden
    return of(mock.find(x => x.id === shopItemId));
  }

  // {size: 4002260, type: "application/octet-stream"}
  // Elméletileg kész
  downloadCiffCaffFile(shopItemId: number): Observable<any> {
    const url = this.baseUrl + `api/caff/${shopItemId}/download`;
    return this.http.get(url, { responseType: 'blob' });
    // return this.http
    //   .get(url, {
    //     responseType: 'blob',
    //   }).pipe(
    //     map(res => {
    //       return new Blob([res], { type: 'application/pdf' });
    //       return {
    //         filename: row.name,
    //         data: res.blob()
    //       };
    //     })
    //   );
  }

  // Elméletileg kész
  updateShopItem(shopItem: IShopItemModel): Observable<void> {
    const url = this.baseUrl + `api/caff/${shopItem.id}`;
    return this.http.put<any>(url, shopItem);
  }

  // Elméletileg kész
  deleteShopItem(shopItemId: number): Observable<void> {
    const url = this.baseUrl + `api/caff/${shopItemId}`;
    return this.http.delete<any>(url);
  }

  deleteComment(commentId: number): Observable<void> {
    const url = this.baseUrl + `api/comment/${commentId}`;
    return this.http.delete<any>(url);
  }

  // Elméletileg kész
  // Így kell form data-t feltölteni
  uploadShopItem(shopItem: IShopItemModel): Observable<void> {
    // mock.push(shopItem);
    const url = this.baseUrl + 'api/caff';
    const formData = new FormData();
    const shopItemDto = {
      ...shopItem
    };
    for (const key in shopItemDto) {
      if (key) {
        formData.append(key, shopItemDto[key]);
      }
    }
    return this.http.post<any>(url, formData);
  }

  addComment(comment: string, shopItemId: number): Observable<any> {
    const url = this.baseUrl + `api/comment/${shopItemId}`;
    return this.http.put<any>(url, { content: comment });
  }
}

// Ez csak tesztelés miatt van bent, hogy látszódjon valami a felületen
const mock: IShopItemModel[] = [
  {
    id: 1,
    title: 'Számbizt házi',
    fileComments: [
      {
        id: 1,
        content: 'Szerintem meg a PS5 a legjobb!!!444!!NÉGY!!!',
        creationDate: new Date(),
        ownerName: 'Levi'
      },
      {
        id: 1,
        content: 'CSAK A PC!!',
        creationDate: new Date(),
        ownerName: 'Meczner',
      },
      {
        id: 1,
        content: 'Be vagyok b@szva xddd',
        creationDate: new Date(),
        ownerName: 'DaniVagyokTshő',
      },
    ],
    description: 'Itt az új Xbox Series X!',
    ownerName: 'Vitya',
    imageUrl: 'https://kep.cdn.indexvas.hu/1/0/3207/32070/320704/32070459_68db62359be24ab16b2103d76892be76_wm.jpg'
  },
  {
    id: 2,
    title: 'Title 2',
    fileComments: [
      {
        id: 1,
        content: 'ASDAD',
        creationDate: new Date(),
        ownerName: 'Jóska'
      },
      {
        id: 1,
        content: 'ASDAD',
        creationDate: new Date(),
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
    fileComments: [
      {
        id: 1,
        content: 'ASDAD',
        creationDate: new Date(),
        ownerName: 'Jóska'
      },
      {
        id: 1,
        content: 'ASDAD',
        creationDate: new Date(),
        ownerName: 'Jóska'
      }
    ],
    description: 'Description 1',
    ownerName: 'Béla',
    imageUrl: 'https://kep.cdn.indexvas.hu/1/0/3207/32070/320704/32070459_68db62359be24ab16b2103d76892be76_wm.jpg'
  },
];