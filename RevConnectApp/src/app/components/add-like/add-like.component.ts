import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-add-like',
  templateUrl: './add-like.component.html',
  styleUrls: ['./add-like.component.css']
})
export class AddLikeComponent implements OnInit {
  @Output() onSubmitLike:EventEmitter<any>=new EventEmitter();
  @Input() postLikes!: any[];
  @Input()authID:any;
  postLike!:any;
  user!:any;
  alreadyliked!:boolean;

  constructor(private auth:AuthService) { }

  ngOnInit(): void {
  }
  submitLike(){
    this.onSubmitLike.emit(this.alreadyliked)
  }

  checkForUserInLikes(){
    if(this.postLikes.length===0)
    {
      this.alreadyliked=false;
      this.submitLike();
    }
    for(let i=0; i<this.postLikes.length; i++ )
    {
      if(this.postLikes[i].authID===this.authID)
      {
        this.alreadyliked=true;
        this.submitLike()
      }
      else if(i===this.postLikes.length-1)
      {
        this.alreadyliked=false;
        this.submitLike();
      }
    }
  }
}
