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

  public getIsLogged(): boolean {
    const logged = localStorage.getItem('token');
    return logged ? true : false;
  }

  public register(model: RegisterRequest): Observable<any> {
    return this.http.post(this.baseUrl + "userauth/register", model);
  }
  public login(model : LoginRequest): Observable<any>{
    return this.http.post<LoginResponse>(this.baseUrl + "userauth/login", model)
  }
  public logout(): void {
    localStorage.removeItem('token');
  }

}
//
