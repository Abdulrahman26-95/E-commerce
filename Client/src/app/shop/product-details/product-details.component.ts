import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from 'src/app/services/shop.service';
import { IProduct } from 'src/app/shared/interfaces/IProduct';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product: IProduct;

  constructor(private shopService: ShopService,
    private activateRoute: ActivatedRoute, private breadcrumbService: BreadcrumbService) {
    this.breadcrumbService.set('@productDetails', ' ')
  }

  ngOnInit() {
    this.getProductById()
  }

  getProductById() {
    this.shopService.getProductById(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe(
        {
          next: response => {
            this.product = response;
            this.breadcrumbService.set('@productDetails', this.product.name)
          },
          error: error => { console.log(error) }
        }
      )
  }

}
