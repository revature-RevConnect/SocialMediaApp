import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/app/Interfaces/UserSocial';
import { AuthService } from '@auth0/auth0-angular';
import { SwitchSettingsService } from 'src/app/services/switch-settings.service';

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

  constructor(private api:ApiService, public auth:AuthService, private ss:SwitchSettingsService) { }

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

  showGeneral():void{
    this.ss.toggleShowGeneral();
    this.ss.toggleShowAboutMe();
  }

  showSocialLinks():void{
    this.ss.toggleShowSocialLinks();
    this.ss.toggleShowAboutMe();
  }

  showTopPost():void{
    this.ss.toggleShowTopPost();
    this.ss.toggleShowAboutMe();
  }
}
