import { Component, OnInit } from '@angular/core';
import { SwitchSettingsService } from 'src/app/services/switch-settings.service';

@Component({
  selector: 'app-top-post',
  templateUrl: './top-post.component.html',
  styleUrls: ['./top-post.component.css']
})
export class TopPostComponent implements OnInit {

  constructor(private ss:SwitchSettingsService) { }

  ngOnInit(): void {
  }

  showGeneral():void{
    this.ss.toggleShowGeneral();
    this.ss.toggleShowTopPost();
  }

  showAboutMe():void{
    this.ss.toggleShowAboutMe();
    this.ss.toggleShowTopPost();
  }

  showSocialLinks():void{
    this.ss.toggleShowSocialLinks();
    this.ss.toggleShowTopPost();
  }

}
