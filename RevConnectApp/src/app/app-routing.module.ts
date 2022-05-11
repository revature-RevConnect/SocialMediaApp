import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ChatroomComponent } from "./pages/chatroom/chatroom.component";
import { HomeComponent } from "./pages/home/home.component";
import { LoginComponent } from "./pages/login/login.component";
import { LogoutComponent } from "./pages/logout/logout.component";
import { SettingsComponent } from "./pages/settings/settings.component";
import { UserProfileComponent } from "./pages/user-profile/user-profile.component";

const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'chatroom', component:ChatroomComponent},
    {path:'login', component:LoginComponent},
    {path:'logout', component:LogoutComponent},
    {path:'settings', component:SettingsComponent},
    {path:'user-profile', component:UserProfileComponent}

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}



