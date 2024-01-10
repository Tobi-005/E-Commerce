import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/models/Product';
import { Brands } from '../shared/models/Brands';
import { Types } from '../shared/models/Types';
import { ShopParams } from '../shared/models/ShopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('search') searchTerm? : ElementRef

  products: Product[] = [];
  brands: Brands[] = [];
  types: Types[] = [];

  totalCount=0;

  shopparams : ShopParams = new ShopParams();


  sortOptions= [
    {name:'Alphabetically', value: 'name'},
    {name:'Price : Low to High', value: 'priceAsc'},
    {name:'Price: High to Low', value: 'priceDsc'}


  ]

  constructor(private ShopService: ShopService) { }

  ngOnInit(): void {

    this.getProducts();
    this.getBrands();
    this.getTypes();

  }


  getProducts() {
    this.ShopService.getProducts(this.shopparams).subscribe({

      next: response =>{ this.products = response.data;
        this.shopparams.pageNumber=response.pageIndex;
        this.shopparams.pageSize=response.pageSize;
        this.totalCount=response.count;
      
      }
      ,
      error: error => console.log(error)


    })
  }

  getBrands() {
    this.ShopService.getBrands().subscribe({

      next: response => this.brands = [{id : 0, name:'All'},...response],
      error: error => console.log(error)


    })
  }

  getTypes() {
    this.ShopService.getTypes().subscribe({

      next: response => this.types = [{id : 0, name:'All'},...response],
      error: error => console.log(error)


    })
  }

  onBrandSelected(brandID : number){
    this.shopparams.brandIDselected=brandID;
    this.shopparams.pageNumber=1;
    this.getProducts();
  }

  
  onTypeSelected(typeID : number){
    this.shopparams.typeIDselected=typeID;
    this.shopparams.pageNumber=1;
    this.getProducts();
  }

  onSortselected(event : any){
    this.shopparams.sortSelected = event.target.value;
    this.getProducts();

  }

  onPageChanged(event :any){
    if(this.shopparams.pageNumber !== event){
      this.shopparams.pageNumber=event;
      this.getProducts();
    }
  }

  onSearch(){
    this.shopparams.search=this.searchTerm?.nativeElement.value;
    this.shopparams.pageNumber=1;
    this.getProducts();
  }

  onReset(){
    if(this.searchTerm) this.searchTerm.nativeElement.search='';
    this.shopparams=new ShopParams();
    this.getProducts();



  }

}

