import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { delay, finalize, Observable } from 'rxjs';
import { SpinnerService } from 'src/app/services/spinner.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private spinnerService:SpinnerService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.spinnerService.busy();
    return next.handle(request).pipe(
      delay(1000),
      finalize(()=>this.spinnerService.idle())
    );
  }
}
