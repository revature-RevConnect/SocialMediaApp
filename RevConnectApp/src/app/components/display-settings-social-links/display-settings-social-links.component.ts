import { Component, OnInit,Input, Output, EventEmitter } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/app/Interfaces/UserSocial';

@Component({
  selector: 'app-display-settings-social-links',
  templateUrl: './display-settings-social-links.component.html',
  styleUrls: ['./display-settings-social-links.component.css']
})
export class DisplaySettingsSocialLinksComponent implements OnInit {
  @Input() user!:any;
  userSocial!:UserSocial
 
  @Output() onSubmitLinkedin: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitTwitter: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitGithub: EventEmitter<UserSocial>=new EventEmitter();

  linkedin!:any;
  twitter!:any;
  github!:any;
  
  constructor(private api:ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser(this.user.sub).subscribe((data)=>this.userSocial=data)
  }

  submitLinkedin(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.userSocial.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.userSocial.aboutMe,
      phone:this.userSocial.phone,
      address:this.userSocial.address,
      linkedin:this.linkedin
    }
    console.log(this.userSocial);
    this.onSubmitLinkedin.emit(this.userSocial);
  }

  submitTwitter(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.userSocial.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.userSocial.aboutMe,
      phone:this.userSocial.phone,
      address:this.userSocial.address,
      linkedin:this.userSocial.linkedin,
      twitter:this.twitter
    }
    console.log(this.userSocial);
    this.onSubmitTwitter.emit(this.userSocial);
  }

  submitGithub(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.userSocial.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.userSocial.aboutMe,
      phone:this.userSocial.phone,
      address:this.userSocial.address,
      linkedin:this.userSocial.linkedin,
      twitter:this.userSocial.twitter,
      github:this.github
    }
    console.log(this.userSocial);
    this.onSubmitGithub.emit(this.userSocial);
  }

}
