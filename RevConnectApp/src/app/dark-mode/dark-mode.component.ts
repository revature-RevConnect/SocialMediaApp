import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dark-mode',
  templateUrl: './dark-mode.component.html',
  styleUrls: ['./dark-mode.component.css']
})

export class DarkModeComponent implements OnInit {

  constructor() { }

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
