import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { DarkmodeService } from 'src/app/services/darkmode.service';

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


  constructor(private dark:DarkmodeService) { }

  toggleShowGeneral():void{
    this.showGeneral=!this.showGeneral;
    this.subjectGeneral.next(this.showGeneral);
    setTimeout(() => this.dark.checkMode(), 0.1);
  }

  onToggleShowGeneral():Observable<any>{
    return this.subjectGeneral.asObservable();

  }
  toggleShowAboutMe():void{
    this.showAboutMe=!this.showAboutMe;
    this.subjectAboutMe.next(this.showAboutMe)
    console.log(this.showGeneral);
    console.log(this.showAboutMe);
    setTimeout(() => this.dark.checkMode(), 0.1);
  }

  onToggleShowAboutMe():Observable<any>{
    return this.subjectAboutMe.asObservable();

  }
  toggleShowSocialLinks():void{
    this.showSocialLinks=!this.showSocialLinks;
    this.subjectSocialLinks.next(this.showSocialLinks);
    setTimeout(() => this.dark.checkMode(), 0.1);
  }

  onToggleShowSocialLinks():Observable<any>{
    return this.subjectSocialLinks.asObservable();

  }
  toggleShowTopPost():void{
    this.showTopPost=!this.showTopPost;
    this.subjectTopPost.next(this.showTopPost);
    setTimeout(() => this.dark.checkMode(), 0.1);
  }

  onToggleShowTopPost():Observable<any>{
    return this.subjectTopPost.asObservable();

  }
}
