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

@NgModule({
  declarations: [
    AppComponent,
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
    GeneralComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    // Import the module into the application, with configuration
    AuthModule.forRoot({
      domain: '',
      clientId: '',
      audience: "https://revconnect-api-endpoint/",
      apiUri: "https://localhost:7140/swagger",
      appUri: "http://localhost:4200",
      httpInterceptor: {
        allowedList: [
          {
            uri: "https://localhost:7140/swagger",
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
