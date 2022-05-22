import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public auth: AuthService ) { }

  ngOnInit(): void {
  }
  darkOn : boolean = false;

  changeMode() {
    let elements = document.getElementsByTagName("*");
    if(this.darkOn == true)
    {
      this.darkOn = false;
      for (let index = 0; index < elements.length; index++) {
      elements[index].classList.remove("active");
      }
    }
    else 
    {
      this.darkOn = true;
      for (let index = 0; index < elements.length; index++) {
      elements[index].classList.add("active");
      }
    }
  }

}
