import { Component, OnInit, EventEmitter, Output,Input } from '@angular/core';
import { AuthService, User } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/app/Interfaces/UserSocial';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  picture!:string;
  user!:any;
  userSocial!:UserSocial;

  constructor(public auth: AuthService, private api:ApiService) {}
    
  ngOnInit(): void {
    this.auth.user$.subscribe((data)=>this.user=data) 

  }

}
