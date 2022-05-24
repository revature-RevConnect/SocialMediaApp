import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';
import { Post } from 'src/app/Interfaces/Post';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  post!:Post;
  user!:any;
  posts!:Post[];

  constructor(public auth:AuthService, public api:ApiService) { }

  ngOnInit(): void {
    this.api.getAllPosts().subscribe((data)=>this.posts=data),
    this.auth.user$.subscribe((profile)=>this.user=profile)
  }

  addNewPost(post:Post){
    this.api.addPost(post).subscribe((post)=>this.posts.unshift(post));
    console.log(post);
  }

}
