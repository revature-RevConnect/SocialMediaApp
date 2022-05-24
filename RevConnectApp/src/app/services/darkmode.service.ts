import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DarkmodeService {

  constructor() { }

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
  checkMode(){
    let elements = document.getElementsByTagName("*");
    if(this.darkOn == true)
    {
      for (let index = 0; index < elements.length; index++) {
        if(!elements[index].classList.contains("active"))
        {
          elements[index].classList.add("active");
          console.log(elements[index]);
        }
      }
    }
    else 
    {
      for (let index = 0; index < elements.length; index++) {
        if(elements[index].classList.contains("active"))
        {
          elements[index].classList.remove("active");
        }
      }
    }
  }
}
