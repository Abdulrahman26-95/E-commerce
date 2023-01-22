import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './interfaces/IPagination';
import { IProduct } from './interfaces/IProduct';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Amir';
  Products: IProduct[];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get("http://localhost:7001/api/products?pageSize=20").subscribe((response: IPagination) => {
      this.Products = response.data;
    }, error => { console.log(Error) }
    )
  }
}
