import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { CoreModule } from '../core/core.module';
import { ShopModule } from '../shop/shop.module';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    ShopModule
  ],
  exports:[HomeComponent]
})
export class HomeModule { }
