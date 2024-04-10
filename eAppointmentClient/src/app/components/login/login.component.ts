import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { LoginModel } from '../../models/login.model';
import { FormValidateDirective } from 'form-validate-angular';
import { HttpService } from '../../services/http.service';
import { LoginResponseModel } from '../../models/login-response.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, FormValidateDirective],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  login: LoginModel = new LoginModel();

  @ViewChild("password") password : ElementRef<HTMLInputElement> | undefined;

  constructor(
    private http: HttpService,
    private router: Router
  ){}

  showOrHidePassword(){
    if(this.password === undefined) return;
    
    if(this.password.nativeElement.type === "password"){
      this.password.nativeElement.type = "text";
    }else{
      this.password.nativeElement.type = "password";
    }
  }

  signIn(form:NgForm){
    if(form.valid){
      this.http.post<LoginResponseModel>("Auth/Login",this.login,(res)=> {
        localStorage.setItem("token", res.data!.token);
        this.router.navigateByUrl("/");
      })
    }
  }
}
