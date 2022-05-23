import { Component, EventEmitter, OnInit, Output,Input } from '@angular/core';
import { UserSocial } from 'src/app/Interfaces/UserSocial'
import { AuthService, User } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';
import { SwitchSettingsService } from 'src/app/services/switch-settings.service';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrls: ['./general.component.css']
})
export class GeneralComponent implements OnInit {
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  picture!:any;
  user!:any;
  userSocial!:UserSocial;
  @Input() showGeneral!:boolean;

  constructor(private api:ApiService, public auth:AuthService, private ss:SwitchSettingsService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe((data)=>this.user=data)
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

  showAboutMe():void{
    this.ss.toggleShowAboutMe();
    this.ss.toggleShowGeneral();
  }

  showSocialLinks():void{
    this.ss.toggleShowSocialLinks();
    this.ss.toggleShowGeneral();
  }

  showTopPost():void{
    this.ss.toggleShowTopPost();
    this.ss.toggleShowGeneral();
  }

}