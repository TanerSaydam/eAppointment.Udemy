import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SwalService } from './swal.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private swal: SwalService
  ) { }

  errorHandler(err: HttpErrorResponse){
    console.log(err);
    let message = "Error!";
    if(err.status === 0){
      message = "API is not available";
    }else if(err.status === 401){
      message = "You are not authorized"
    }
    else if(err.status === 404){
      message = "API not found";
    }else if(err.status === 500){
      message = "";
      for(const e of err.error.errorMessages){
        message += e + "\n";
      }
    }

    this.swal.callToast(message,"error");
  }
}
