import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from '../services/shop.service';
import { IBrand } from '../shared/interfaces/IBrand';
import { IProduct } from '../shared/interfaces/IProduct';
import { IProductType } from '../shared/interfaces/IProductType';
import { ShopParams } from '../shared/ShopParams';


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  Products: IProduct[];
  Brands: IBrand[];
  Types: IProductType[];

  // Get Parameter From ShopParameter Calss
  shopParam = new ShopParams();
  totalProducts: number;

  // Pagination
  showBoundaryLinks = true;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price : Low To High', value: 'priceAsc' },
    { name: 'Price : High To Low', value: 'priceDesc' }
  ]
  // Searching
  @ViewChild('search',{static:true}) searchTerm:ElementRef;

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getProducts()
    this.getBrands()
    this.getTypes()
  }
  // Get All Products
  getProducts() {
    this.shopService.getAllProducts(this.shopParam)
      .subscribe({next:response => {
        this.Products = response.data;
        this.shopParam.pageIndex = response.pageIndex;
        this.shopParam.pageSize = response.pageSize;
        this.totalProducts = response.count;
      },
        error:error => { console.log(error) }}
      );
  }
  // Filter Products By Brands And Types 
  pickProductsByBrand(brandId: number) {
    this.shopParam.brandId = brandId;
    this.shopParam.pageIndex=1;
    console.log(brandId)
    this.getProducts();
  }
  pickProductsByType(typeId: number) {
    this.shopParam.typeId = typeId;
    this.shopParam.pageIndex=1;
    console.log(typeId)
    this.getProducts();
  }
  // Sort Products By Price 
  pickProductsBySorting(sort: string) {
    this.shopParam.sort = sort;
    this.getProducts();
  }
  // Styling
  activeClass(id: any) {
    console.log('Enter ID', id)
    document.getElementById(id).classList.add('activeLocal')
  }
  removeActiveClass(id: any) {
    console.log('leave id:', id);
    document.getElementById(id).classList.remove('activeLocal');
  }
  // Get ProductBrands 
  getBrands() {
    this.shopService.getBrands().subscribe({next:response => {
      this.Brands =
        [{ id: 0, name: "All" }, ...response]
    },
      error:error => { console.log(error) }}
      )
  }
  // Get ProductTypes
  getTypes() {
    this.shopService.getTypes()
      .subscribe({next:response => { this.Types = [{ id: 0, name: "All" }, ...response] },
        error:error => { console.log(error) }}
        )
  }
  // Pagination
  onChangePage(event: any) {
    if(this.shopParam.pageIndex!==event){
      this.shopParam.pageIndex = event;
      console.log(this.shopParam.pageIndex)
      this.getProducts();
    }
  }
// Searching 
onSearch(){
  this.shopParam.search=this.searchTerm.nativeElement.value;
  this.shopParam.pageIndex=1;
  this.getProducts();
}
onReset(){
this.searchTerm.nativeElement.value= "";
this.shopParam=new ShopParams();
this.getProducts();
}
}
