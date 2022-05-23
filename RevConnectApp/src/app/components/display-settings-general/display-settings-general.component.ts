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
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitUsername: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitAboutMe: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitPhone: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitAddress: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitLinkedin: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitTwitter: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitGithub: EventEmitter<UserSocial>=new EventEmitter();
  userSocial!:UserSocial;
  picture!:any;
  name!:any;
  aboutMe!:any;
  phone!:any;
  address!:any;
  linkedin!:any;
  twitter!:any;
  github!:any;
  postedFile!:File;

  constructor(private api:ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser(this.user.sub).subscribe((data)=>this.userSocial=data)
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

  submitPhone(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.userSocial.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.userSocial.aboutMe,
      phone:this.phone
    }
    console.log(this.userSocial);
    this.onSubmitPhone.emit(this.userSocial);
  }

  submitAddress(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.userSocial.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.userSocial.aboutMe,
      phone:this.userSocial.phone,
      address:this.address
    }
    console.log(this.userSocial);
    this.onSubmitAddress.emit(this.userSocial);
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

  onFileSelected(event: any) 
  {
    this.postedFile=<File>event.target.files[0]; 
    console.log(this.postedFile);
  }

  onUpload(){
    const formData:FormData = new FormData();
    formData.append('postedFile', this.postedFile, this.user);
    console.log(formData);

    const photo = {
      authID:this.userSocial.authID,
      data:formData,
    }
    //this.api.postPicture(photo).subscribe((data)=>this.userSocial.profilePicture=data);
    this.onSubmitPicture.emit(photo);
  }

}
