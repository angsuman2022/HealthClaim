import { Component,OnInit } from '@angular/core';
import {LoginServiceService } from '../services/login-service.service';
import {LoginData} from '../models/logindata';
import{Router} from '@angular/router';

@Component({
  selector: 'login-root',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  constructor(private _service:LoginServiceService,private _router:Router) { }
  LogindataModel:LoginData=new LoginData();
  Errormsg:any='';
  ngOnInit(): void {
  }
  registerclick()
  {
    this._router.navigate(['register']);
  }
  loginUser()
  {
    var userdto = {
      userName: this.LogindataModel.userName,
      password: this.LogindataModel.password
      
    };
    this._service.loginUser(userdto).subscribe(res=>{
     /*  console.log('Hi you are able to login');
      alert('Hi'); */
      localStorage.setItem('token',res.token);
      localStorage.setItem('userid',res.userid);
      localStorage.setItem('role',res.role);
      if(localStorage.getItem('role')=="Admin")
         this._router.navigate(['adminpage/add']);
         else
         this._router.navigate(['memberpage/add']);

    }, res=>
    {
      console.log(res);
      this.Errormsg="Wrong UserName or Password";
      document.getElementById('btnerrormsg')?.click();


    }
  );
  }
}
