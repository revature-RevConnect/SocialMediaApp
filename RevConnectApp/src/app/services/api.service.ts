import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from '../Interfaces/Post';
import { Like } from '../Interfaces/Like';
import { Comment } from '../Interfaces/Comment';
import { UserSocial } from '../Interfaces/UserSocial';
import { AuthService } from '@auth0/auth0-angular';

const httpOptions ={
  headers: new HttpHeaders({
    'Content-Type': 'application/problem+json',
  }),
};

const url='https://revconnect-api-endpoint/'

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient, public auth:AuthService) { }

  addPost(post:Post):Observable<Post>{
    return this.http.post<Post>(`${url}/Posts`, post, httpOptions);
  }

  updatePicture(user:UserSocial):Observable<UserSocial>{
    return this.http.put<UserSocial>(`${url}/Users/picture`, user ,httpOptions);
  }

  updateUsername(user:UserSocial):Observable<UserSocial>{
    return this.http.put<UserSocial>(`${url}/Users/username`, user ,httpOptions);
  }

  updateAboutMe(user:UserSocial):Observable<UserSocial>{
    return this.http.put<UserSocial>(`${url}/Users/aboutMe`, user ,httpOptions);
  }

  updatePhone(user:UserSocial):Observable<UserSocial>{
    return this.http.put<UserSocial>(`${url}/Users/phone`, user ,httpOptions);
  }

  updateEmail(user:UserSocial):Observable<UserSocial>{
    return this.http.put<UserSocial>(`${url}/Users/email`, user ,httpOptions);
  }

  updateAddress(user:UserSocial):Observable<UserSocial>{
    return this.http.put<UserSocial>(`${url}/Users/address`, user ,httpOptions);
  }

  getCurrentUser(authID:any):Observable<UserSocial>{
    return this.http.get<UserSocial>(`${url}/Users/${authID}`);
  }

  getAllPosts():Observable<Post[]>{
    return this.http.get<Post[]>(`${url}/Posts/all`);
  }
  getAllPostComments(postID:any):Observable<Comment[]>{
    return this.http.get<Comment[]>(`${url}/Comments/all/${postID}`);
  }
  getAllPostLikes(postID:any):Observable<Like[]>{
    return this.http.get<Like[]>(`${url}/Likes/${postID}`);
  }
  commentOnPost(newComment:Comment):Observable<Comment>{
    return this.http.post<Comment>(`${url}/Comments`, newComment, httpOptions);
  }
  likePost(newLike:Like):Observable<Like>{
    return this.http.post<Like>(`${url}/Likes/post`, newLike, httpOptions);
  }
}
