import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {UserLogged} from "../models/userLogged.model";
import { BehaviorSubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { UserLogin } from '../models/userLogin.model';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
     
  constructor(private http: HttpClient) {
  }
  loggedUserSubject= new BehaviorSubject<UserLogged>(null as any);
  loggedUserData=this.loggedUserSubject.asObservable();

  login(userLogin : UserLogin ) {
      let body={
        "username": userLogin.username,
        "password": userLogin.password
      };
      console.log(body);
      
      return this.http.post<UserLogged>('http://localhost:5000/api/auth/login', body, { 
        headers: new HttpHeaders({
          "Content-Type": "application/json"        
        })
      }).pipe(map(response=>{
        localStorage.setItem('loggedInUser', JSON.stringify(response));
        console.log(response);
        this.loggedUserSubject.next(response);
      }));
  }

  get user(): UserLogged{
    const user = JSON.parse(localStorage.getItem('loggedInUser'));
    if(user != null){
      return user;
    }
    return null;
  }

  public isLogged():boolean{
    const jwtHelper = new JwtHelperService();
    return !jwtHelper.isTokenExpired(this.getToken());
  }

  public logout(){
    localStorage.removeItem('loggedInUser');
    this.loggedUserSubject.next(null);
  }

  private getToken(){
    const loggedInUser = JSON.parse(localStorage.getItem('loggedInUser'));
    if(loggedInUser){
      let token = loggedInUser.jwtToken;
      return token;
    }
    return null;
  }

}
        