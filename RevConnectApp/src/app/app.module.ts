import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


// Import the module from the SDK
import { AuthModule } from '@auth0/auth0-angular';


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
    AppLoadingComponent
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
      domain: 'dev-1kna-o7p.us.auth0.com',
      clientId: '4mbrJbRZJKwRbCK5p3zByC9HB6httr9Y'
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
