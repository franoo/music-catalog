import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private authService: AuthService) { }
  loggedUser = '';

  ngOnInit(): void {
    this.loggedUser = this.authService.username;
    console.log(this.loggedUser);
  }

}
