import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopItemComponent } from './components/shop-item/shop-item.component';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    ShopItemComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatButtonModule
  ],
  exports: [
    ShopItemComponent
  ]
})
export class SharedModule { }
