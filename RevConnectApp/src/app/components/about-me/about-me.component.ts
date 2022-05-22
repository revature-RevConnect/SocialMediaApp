import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/app/Interfaces/UserSocial';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-about-me',
  templateUrl: './about-me.component.html',
  styleUrls: ['./about-me.component.css']
})
export class AboutMeComponent implements OnInit {
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  picture!:any;
  user!:any;
  userSocial!:UserSocial;

  constructor(private api:ApiService, public auth:AuthService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe((data)=>this.user=data);
  }

  getUserProfile(){
    this.api.getCurrentUser(this.user.sub).subscribe((data)=>this.userSocial=data);
    console.log(this.userSocial);
  }

  updateUserPicture(photo:any){
    this.api.postPicture(photo).subscribe((data)=>this.user=data);
  }

  updateUsername(userSocial:UserSocial){
    this.api.updateUsername(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

  updateAboutMe(userSocial:UserSocial){
    this.api.updateAboutMe(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }
}
