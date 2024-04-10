import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResultModel } from '../models/result.model';
import { api } from '../constants';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(
    private http: HttpClient,
    private error: ErrorService
  ) { }

  post<T>(apiUrl:string, body:any, callBack: (res:ResultModel<T>)=> void, errCallBack?: (err: HttpErrorResponse)=> void){
    this.http.post<ResultModel<T>>(`${api}/${apiUrl}`,body)
    .subscribe({
      next: (res=> {
        callBack(res);      
      }),
      error: ((err:HttpErrorResponse)=> {
        this.error.errorHandler(err);

        if(errCallBack !== undefined){                    
          errCallBack(err);
        }        
      })
    })
  }
}
