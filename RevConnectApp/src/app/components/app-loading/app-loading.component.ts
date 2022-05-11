import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-app-loading',
  templateUrl: './app-loading.component.html',
  styleUrls: ['./app-loading.component.css']
})
export class AppLoadingComponent implements OnInit {
  loadingImg =
    'https://cdn.auth0.com/blog/auth0-react-sample/assets/loading.svg';

  constructor() { }

  ngOnInit(): void {
  }

}
