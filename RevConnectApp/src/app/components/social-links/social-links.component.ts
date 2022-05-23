import { Component, OnInit } from '@angular/core';
import { SwitchSettingsService } from 'src/app/services/switch-settings.service';

@Component({
  selector: 'app-social-links',
  templateUrl: './social-links.component.html',
  styleUrls: ['./social-links.component.css']
})
export class SocialLinksComponent implements OnInit {

  constructor(private ss:SwitchSettingsService) { }

  ngOnInit(): void {
  }

  showGeneral():void{
    this.ss.toggleShowGeneral();
    this.ss.toggleShowSocialLinks();
  }

  showAboutMe():void{
    this.ss.toggleShowAboutMe();
    this.ss.toggleShowSocialLinks();
  }

  showTopPost():void{
    this.ss.toggleShowTopPost();
    this.ss.toggleShowSocialLinks();
  }

}
