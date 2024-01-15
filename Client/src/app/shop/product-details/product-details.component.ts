import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/models/Product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product?: Product

 

  constructor(private shopservice : ShopService, private activatedRoute : ActivatedRoute) {}

  ngOnInit(): void {
    this.loadProduct();
  }


  loadProduct() {
    const id= this.activatedRoute.snapshot.paramMap.get('id');

    if(id) this.shopservice.getProduct(+id).subscribe({
      next : p => this.product = p,
      error : error => console.log(error)

    })
  }

  

}
