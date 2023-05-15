import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient) { }

  public register(user : User): Observable<any>{
    return this.http.post<any>("https://localhost:7099/api/UserAuth/Register", user)
  }
  public login(user: User): Observable<any>{
    return this.http.post<any>("https://localhost:7099/api/UserAuth/Login", user,
  {
    responseType: 'json',
  })
  }

}
//
