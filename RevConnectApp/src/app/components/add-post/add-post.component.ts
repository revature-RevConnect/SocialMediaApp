import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Post } from 'src/app/Interfaces/Post';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {
  @Output() onSubmitPost: EventEmitter<Post>=new EventEmitter();
  body!: string;
  title!:string;
  @Input() authID:any;
  userSocial:any;
  constructor(public auth:AuthService, private api:ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser(this.authID).subscribe((data)=>this.userSocial=data);
  }

    onSubmit(){
    const newPost={
      postID:0,
      title:this.title,
      body:this.body,
      authID:this.authID,
    };
    this.onSubmitPost.emit(newPost);
    console.log(newPost);
  }

}
