import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'RevConnectApp';
  constructor(public auth: AuthService) {}

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


