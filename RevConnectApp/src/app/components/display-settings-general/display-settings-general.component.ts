import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/app/Interfaces/UserSocial';

@Component({
  selector: 'app-display-settings-general',
  templateUrl: './display-settings-general.component.html',
  styleUrls: ['./display-settings-general.component.css']
})
export class DisplaySettingsGeneralComponent implements OnInit {
  @Input() user!:any;
  userSocial!:UserSocial
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitUsername: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitAboutMe: EventEmitter<UserSocial>=new EventEmitter();
  picture!:any;
  name!:any;
  aboutMe!:any;

  constructor(private api:ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser(this.user.sub).subscribe((data)=>this.userSocial=data)
  }
  submitPicture(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.userSocial.name,
      profilePicture:this.picture,
      aboutMe:this.userSocial.aboutMe
    }
    console.log(this.userSocial);
    this.onSubmitPicture.emit(this.userSocial);
  }

  submitUsername(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.userSocial.aboutMe
    }
    console.log(this.userSocial);
    this.onSubmitUsername.emit(this.userSocial);
  }

  submitAboutMe(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.userSocial.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.aboutMe
    }
    console.log(this.userSocial);
    this.onSubmitAboutMe.emit(this.userSocial);
  }

}
