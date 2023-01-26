import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ShopModule } from './shop.module';

const routes:Routes = [
    {path: '', component:ShopComponent},
    {path: ':id',component:ProductDetailsComponent},
]
@NgModule({
    declarations:[],
    imports:[
        // forChild Means that shop Module is not available in app Module, only in this Module ( Lazy Lodding )
    RouterModule.forChild(routes)
    ],
    exports:[RouterModule]
})
export class ShopRoutingModule{

}