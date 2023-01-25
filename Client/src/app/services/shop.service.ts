import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IBrand } from '../shared/interfaces/IBrand';
import { IPagination } from '../shared/interfaces/IPagination';
import { IProductType } from '../shared/interfaces/IProductType';
import { ShopParams } from '../shared/ShopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = "https://localhost:7000/api/";
  constructor(private http: HttpClient) { }

  getAllProducts(shopParam: ShopParams) {
    let params = new HttpParams();
    if (shopParam.brandId > 0) {
      params = params.append('brandId', shopParam.brandId.toString());
    }
    if (shopParam.typeId > 0) {
      params = params.append('typeId', shopParam.typeId.toString());
    }
    if(shopParam.search){
      params=params.append('search',shopParam.search)
    }
    params = params.append('sort', shopParam.sort);
    params = params.append('pageIndex', shopParam.pageIndex.toString());
    params = params.append('pageSize', shopParam.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        map(
          response => { return response.body })
      );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands')
  }
  getTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'products/types')
  }
}
