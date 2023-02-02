import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.scss']
})
export class TestErrorsComponent {
baseUrl=environment.apiUrl
validationErrors:string[]=[]

constructor(private http:HttpClient){}

get404Error(){
  this.http.get(this.baseUrl+'products/100').subscribe(
    {
    next:response=>console.log(response),
    error:error=>console.log(error)
    }
    )
}

get500error(){
  this.http.get(this.baseUrl+'buggy/servererror').subscribe({
    next:response=>console.log(response),
    error:error=>console.log(error)
  })
}

get400Error(){
  this.http.get(this.baseUrl+'buggy/badRequest').subscribe({
    next:response=>console.log(response),
    error:error=>console.log(error)
  })
}

get400ValidationError(){
  this.http.get(this.baseUrl+'buggy/badRequest/Four').subscribe({
    next:response=>console.log(response),
    error:error=>{
      console.log(error)
      this.validationErrors=error.errors
    }
  })
}
}
