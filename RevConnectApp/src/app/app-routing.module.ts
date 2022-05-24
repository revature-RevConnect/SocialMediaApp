import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ChatroomComponent } from "./pages/chatroom/chatroom.component";
import { HomeComponent } from "./pages/home/home.component";
import { SettingsComponent } from "./pages/settings/settings.component";
import { UserProfileComponent } from "./pages/user-profile/user-profile.component";
import { AboutMeComponent } from "./components/about-me/about-me.component";
import { SocialLinksComponent } from "./components/social-links/social-links.component";
import { TopPostComponent } from "./components/top-post/top-post.component";
import { GeneralComponent } from "./components/general/general.component";

import { AuthGuard } from "@auth0/auth0-angular";

const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'chatroom', component:ChatroomComponent},
    {path:'settings', component:SettingsComponent},
    {path:'user-profile', component:UserProfileComponent}
    //{path:'about-me', component:AboutMeComponent},
    //{path:'social-links', component: SocialLinksComponent },
    //{path:'top-post', component: TopPostComponent},
    //{path:'general', component:GeneralComponent}

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}



