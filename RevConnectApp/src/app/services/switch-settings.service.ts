import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SwitchSettingsService {
  showGeneral:boolean=true;
  showAboutMe:boolean=false;
  showSocialLinks:boolean=false;
  showTopPost:boolean=false;
  private subjectGeneral=new Subject<any>();
  private subjectAboutMe=new Subject<any>();
  private subjectSocialLinks=new Subject<any>();
  private subjectTopPost=new Subject<any>();


  constructor() { }

  toggleShowGeneral():void{
    this.showGeneral=!this.showGeneral;
    this.subjectGeneral.next(this.showGeneral)
  }

  onToggleShowGeneral():Observable<any>{
    return this.subjectGeneral.asObservable();

  }
  toggleShowAboutMe():void{
    this.showAboutMe=!this.showAboutMe;
    this.subjectAboutMe.next(this.showAboutMe)
    console.log(this.showGeneral);
    console.log(this.showAboutMe);
  }

  onToggleShowAboutMe():Observable<any>{
    return this.subjectAboutMe.asObservable();

  }
  toggleShowSocialLinks():void{
    this.showSocialLinks=!this.showSocialLinks;
    this.subjectSocialLinks.next(this.showSocialLinks)
  }

  onToggleShowSocialLinks():Observable<any>{
    return this.subjectSocialLinks.asObservable();

  }
  toggleShowTopPost():void{
    this.showTopPost=!this.showTopPost;
    this.subjectTopPost.next(this.showTopPost)
  }

  onToggleShowTopPost():Observable<any>{
    return this.subjectTopPost.asObservable();

  }
}
