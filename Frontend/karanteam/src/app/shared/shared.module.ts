import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopItemComponent } from './components/shop-item/shop-item.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [ShopItemComponent],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class SharedModule { }
