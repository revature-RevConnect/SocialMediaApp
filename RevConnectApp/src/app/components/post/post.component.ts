import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';
import { Post } from 'src/app/Interfaces/Post';
import { Like } from 'src/app/Interfaces/Like';
import { Comment } from 'src/app/Interfaces/Comment';
import { UserSocial } from 'src/app/Interfaces/UserSocial';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  @Input() post!:Post;
  @Input() authID:any;
  postLikes!:Like[];
  postComments!:Comment[];
  postAuthor!:UserSocial;
  newLike!:any;
  receivedLike:any;

  constructor(public auth:AuthService, private api:ApiService) { }

  ngOnInit(): void {
    this.api.getAllPostLikes(this.post.postID).subscribe((likes)=>this.postLikes=likes),
    this.api.getCurrentUser(this.post.authID).subscribe((author)=>this.postAuthor=author);
    this.api.getAllPostComments(this.post.postID).subscribe((comments)=>this.postComments=comments)
    
  }

  submitLike(alreadyliked:boolean){
    if(alreadyliked===true)
    {
      const newLike={
        likeID:-1,
        postID:this.post.postID,
        commentID:null,
        authID:this.authID
      }
      this.api.likePost(newLike).subscribe((like)=>(this.postLikes.pop()));
    }
    else{
      const newLike={
        likeID:0,
        postID:this.post.postID,
        commentID:null,
        authID:this.authID
      }
      this.api.likePost(newLike).subscribe((like)=>(this.postLikes.push(like)));
    }
  }

  submitComment(newComment:Comment){
    this.api.commentOnPost(newComment).subscribe((data)=>(this.postComments.push(data)));
    console.log(newComment);
  }

}
