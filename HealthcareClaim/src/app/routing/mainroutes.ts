import { HomeComponent } from "../home/home.component";
import { LoginComponent } from "../login/login.component";
import { RegisterComponent } from "../register/register.component";
import { AuthgaurdService } from "../services/authgaurd.service";
export const Mainroutes=[
{path:'',component:RegisterComponent},
{path:'home',canActivate:[AuthgaurdService],component:HomeComponent},
{path:'register',component:RegisterComponent},
{path:'login',component:LoginComponent},
{ path: 'adminpage',canActivate:[AuthgaurdService], loadChildren: () => import('../adminpage/adminpage.module').then(m => m.AdminpageModule) },
{ path: 'memberpage',canActivate:[AuthgaurdService], loadChildren: () => import('../memberpage/memberpage.module').then(m => m.MemberpageModule) },
];
