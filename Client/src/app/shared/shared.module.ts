import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './Components/paging-header/paging-header.component';
import { PagingFooterComponent } from './Components/paging-footer/paging-footer.component';


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagingFooterComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PagingFooterComponent
  ]
})
export class SharedModule { }
