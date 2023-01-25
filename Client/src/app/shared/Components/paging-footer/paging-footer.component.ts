import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-paging-footer',
  templateUrl: './paging-footer.component.html',
  styleUrls: ['./paging-footer.component.scss']
})
export class PagingFooterComponent implements OnInit {
@Input() totalProducts:number;
@Input() pageSize:number;
@Output() pageChanged=new EventEmitter<number>()

constructor(){}

ngOnInit(){}
onPageChanger(event:any){
  this.pageChanged.emit(event.page)
}
}
