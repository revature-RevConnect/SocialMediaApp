import { Component, EventEmitter, OnInit, Output,Input } from '@angular/core';
import { UserSocial } from 'src/app/Interfaces/UserSocial'
import { AuthService, User } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';
import { SwitchSettingsService } from 'src/app/services/switch-settings.service';

@Component({
  selector: 'app-social-links',
  templateUrl: './social-links.component.html',
  styleUrls: ['./social-links.component.css']
})
export class SocialLinksComponent implements OnInit {
  @Input() user!:any;
  userSocial!:UserSocial
 
  @Output() onSubmitLinkedin: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitTwitter: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitGithub: EventEmitter<UserSocial>=new EventEmitter();

  linkedin!:any;
  twitter!:any;
  github!:any;

  constructor(private api:ApiService, public auth:AuthService, private ss:SwitchSettingsService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe((data)=>this.user=data)
  }

  updateLinkedin(userSocial:UserSocial){
    this.api.updateLinkedin(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

  updateTwitter(userSocial:UserSocial){
    this.api.updateTwitter(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

  updateGithub(userSocial:UserSocial){
    this.api.updateGithub(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

  showGeneral():void{
    this.ss.toggleShowGeneral();
    this.ss.toggleShowSocialLinks();
  }

  showAboutMe():void{
    this.ss.toggleShowAboutMe();
    this.ss.toggleShowSocialLinks();
  }

  showTopPost():void{
    this.ss.toggleShowTopPost();
    this.ss.toggleShowSocialLinks();
  }

}
