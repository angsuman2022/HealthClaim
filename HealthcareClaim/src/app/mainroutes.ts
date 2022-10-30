import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { AuthgaurdService } from "./services/authgaurd.service";
export const Mainroutes=[
{path:'',component:LoginComponent},
{path:'home',canActivate:[AuthgaurdService],component:HomeComponent},
{path:'register',component:RegisterComponent},
{path:'login',component:LoginComponent},
];
