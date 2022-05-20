import { Component, OnInit,Input, Output, EventEmitter } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/app/Interfaces/UserSocial';

@Component({
  selector: 'app-display-settings-aboutme',
  templateUrl: './display-settings-aboutme.component.html',
  styleUrls: ['./display-settings-aboutme.component.css']
})
export class DisplaySettingsAboutmeComponent implements OnInit {
  @Input() user!:any;
  userSocial!:UserSocial
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitUsername: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitAboutMe: EventEmitter<UserSocial>=new EventEmitter();
  picture!:any;
  name!:any;
  aboutMe!:any;
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
