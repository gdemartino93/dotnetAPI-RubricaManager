import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginRequest, LoginResponse, RegisterRequest } from 'src/app/models/authModels/auth';
import { User, } from 'src/app/models/user';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = environment.baseUrl;
  constructor(private http : HttpClient) { }

  public register(model: RegisterRequest){
    return this.http.post(this.baseUrl + "Register", model)
  }
  public login(model : LoginRequest){
    return this.http.post<LoginResponse>(this.baseUrl + "Login", model)
  }

}
//
