import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ChatroomComponent } from "./pages/chatroom/chatroom.component";
import { HomeComponent } from "./pages/home/home.component";
import { SettingsComponent } from "./pages/settings/settings.component";
import { UserProfileComponent } from "./pages/user-profile/user-profile.component";
import { AuthGuard } from "@auth0/auth0-angular";

const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'chatroom', component:ChatroomComponent},
    {path:'settings', component:SettingsComponent},
    {path:'user-profile', component:UserProfileComponent}

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}



