import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './models/Product';
import {Pagination} from './models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Tobi';
  products: Product[] =[];

  constructor(private http:HttpClient){}

  
  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>("https://localhost:5001/api/product?PageSize=50").subscribe({
      next: response => this.products = response.data, //what to do next once data is got
      error: error => console.log(error), //what to do if there was an error
      complete: () => { //once whole thing is completed
        console.log('Response is complete');
        console.log('This is for extra statements');
      }
    })
  }


}
