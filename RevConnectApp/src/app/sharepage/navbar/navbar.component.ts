import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DarkmodeService } from 'src/app/services/darkmode.service';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public auth: AuthService, private dark:DarkmodeService ) { }

  ngOnInit(): void {
  }
 

  changeMode() {
    this.dark.changeMode()
  }
}
