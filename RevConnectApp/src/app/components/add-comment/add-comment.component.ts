import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Comment } from 'src/app/Interfaces/Comment';
import { UserSocial } from 'src/app/Interfaces/UserSocial';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent implements OnInit {
  body!:string;
  @Output() onSubmitComment:EventEmitter<Comment> = new EventEmitter();
  @Input() authID:any;
  @Input() postID:any;
  userSocial!:UserSocial;

  constructor(private api:ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser(this.authID).subscribe((data)=>this.userSocial=data);
  }

  onSubmit(){
    const newComment={
      commentID:0,
      body:this.body, 
      authID:this.authID,
      postID:this.postID,
      commentLikes:null     
    }
    console.log(newComment)
    this.onSubmitComment.emit(newComment)

  }
}
