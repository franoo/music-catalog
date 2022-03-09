import { Component, OnInit } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserLogged } from '../models/userLogged.model';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }
  loggedUser: UserLogged;

  ngOnInit(): void {
    this.authService.loggedUserSubject.subscribe(data=>{
      this.loggedUser = data;
    });
    this.loggedUser = this.authService.user;
  }

  onLogout(){
    this.authService.logout();
    this.router.navigate(["/login"]);
  }

}
