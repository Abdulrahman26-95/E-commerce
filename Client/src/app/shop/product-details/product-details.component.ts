import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from 'src/app/services/shop.service';
import { IProduct } from 'src/app/shared/interfaces/IProduct';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product:IProduct;

  constructor(private shopService:ShopService,
    private activateRoute:ActivatedRoute){}

  ngOnInit(){
    this.getProductById()
  }

  getProductById(){
    this.shopService.getProductById(+this.activateRoute.snapshot.paramMap.get('id'))
    .subscribe({next:response=>{this.product=response},
      error:error=>{console.log(error)}
    }
      )
  }
  
}
