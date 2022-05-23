import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { UserSocial } from 'src/app/Interfaces/UserSocial';
import { AuthService, User } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';
import { SwitchSettingsService } from 'src/app/services/switch-settings.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  picture!:any;
  user!:any;
  phone!:any;
  address!:any;
  userSocial!:UserSocial;
  subscription!:Subscription;
  showGeneral:boolean=true;
  showAboutMe:boolean=false;
  showSocialLinks:boolean=false;
  showTopPost:boolean=false;

  constructor(private api:ApiService, public auth:AuthService, private switchSettingsService:SwitchSettingsService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe((data)=>this.user=data);
    this.subscription=this.switchSettingsService.onToggleShowGeneral().subscribe(value=>this.showGeneral=value)
    this.subscription=this.switchSettingsService.onToggleShowAboutMe().subscribe(value=>this.showAboutMe=value)
    this.subscription=this.switchSettingsService.onToggleShowSocialLinks().subscribe(value=>this.showSocialLinks=value)
    this.subscription=this.switchSettingsService.onToggleShowTopPost().subscribe(value=>this.showTopPost=value)
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

  updatePhone(userSocial:UserSocial){
    this.api.updatePhone(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

  updateAddress(userSocial:UserSocial){
    this.api.updateAddress(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

}