import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// Import the module from the SDK
import { AuthModule, AuthHttpInterceptor } from '@auth0/auth0-angular';

import { AppComponent } from './app.component';
import { NavbarComponent } from './sharepage/navbar/navbar.component';
import { FooterComponent } from './sharepage/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { ChatroomComponent } from './pages/chatroom/chatroom.component';
import { LoginButtonComponent } from './components/login-button/login-button.component';
import { LogoutButtonComponent } from './components/logout-button/logout-button.component';
import { AppLoadingComponent } from './components/app-loading/app-loading.component';
import { DarkModeComponent } from './components/dark-mode/dark-mode.component';
import { SocialLinksComponent } from './components/social-links/social-links.component';
import { AboutMeComponent } from './components/about-me/about-me.component';
import { TopPostComponent } from './components/top-post/top-post.component';
import { GeneralComponent } from './components/general/general.component';
import { DisplaySettingsGeneralComponent } from './components/display-settings-general/display-settings-general.component';
import { DisplaySettingsAboutmeComponent } from './components/display-settings-aboutme/display-settings-aboutme.component';
import { DisplaySettingsSocialLinksComponent } from './components/display-settings-social-links/display-settings-social-links.component';
import { DisplaySettingsTopPostComponent } from './components/display-settings-top-post/display-settings-top-post.component';
import { DisplayProfileComponent } from './components/display-profile/display-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    DarkModeComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    UserProfileComponent,
    SettingsComponent,
    ChatroomComponent,
    LoginButtonComponent,
    LogoutButtonComponent,
    AppLoadingComponent,
    DarkModeComponent,
    SocialLinksComponent,
    AboutMeComponent,
    TopPostComponent,
    GeneralComponent,
    DisplaySettingsGeneralComponent,
    DisplaySettingsAboutmeComponent,
    DisplaySettingsSocialLinksComponent,
    DisplaySettingsTopPostComponent,
    DisplayProfileComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    //Import the module into the application, with configuration
    AuthModule.forRoot({
      domain: 'dev-1kna-o7p.us.auth0.com',
      clientId: '4mbrJbRZJKwRbCK5p3zByC9HB6httr9Y',
      audience: "https://revconnect-api-endpoint/",
      apiUri: "https://revconnect.azurewebsites.net/",
      appUri: "http://localhost:4200",
      httpInterceptor: {
        allowedList: [
          {
            uri: "https://revconnect.azurewebsites.net/*",
            tokenOptions: {
              audience: 'https://revconnect-api-endpoint/',
            }
          }
        ]
      }
    }),
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
