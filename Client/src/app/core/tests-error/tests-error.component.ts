import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-tests-error',
  templateUrl: './tests-error.component.html',
  styleUrls: ['./tests-error.component.scss']
})
export class TestsErrorComponent {

  baseUrl=environment.apiUrl;

  validationErrors :string[] =[];

  constructor(private httpClient: HttpClient) {}

  get404Error () {
    this.httpClient.get(this.baseUrl + 'product/43').subscribe({

      next : response => console.log(response),
      error: error => console.log(error)
      
      

    })
  }

  get500Error () {
    this.httpClient.get(this.baseUrl + 'buggy/servererror').subscribe({

      next : response => console.log(response),
      error: error => console.log(error)
      
      

    })
  }

  get400Error () {
    this.httpClient.get(this.baseUrl + 'buggy/badrequest').subscribe({

      next : response => console.log(response),
      error: error => {
        console.log(error)
       
      }
      
      

    })
  }

  get400ValidationError () {
    this.httpClient.get(this.baseUrl + 'product/fortytwo').subscribe({

      next : response => console.log(response),
      error: error => {
        console.log(error),
        this.validationErrors=error.errors;
      }
      
      

    })
  }

}
