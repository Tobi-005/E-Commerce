import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/Pagination';
import { Product } from '../shared/models/Product';
import { Brands } from '../shared/models/Brands';
import { Types } from '../shared/models/Types';
import { ShopParams } from '../shared/models/ShopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(Shopparams : ShopParams) {
    let params=new HttpParams();

    if(Shopparams.brandIDselected > 0) params=params.append("brandId",Shopparams.brandIDselected);
    if(Shopparams.typeIDselected > 0) params=params.append("typeId",Shopparams.typeIDselected);
    params=params.append("sort",Shopparams.sortSelected);
    params=params.append("pageIndex",Shopparams.pageNumber);
    params=params.append("pageSize",Shopparams.pageSize);
    if(Shopparams.search) params=params.append("search",Shopparams.search);




    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'product',{params:params});
  }

  getBrands() {
    return this.http.get<Brands[]>(this.baseUrl + 'product/brands');
  }

  getTypes() {
    return this.http.get<Types[]>(this.baseUrl + 'product/types');
  }



}
