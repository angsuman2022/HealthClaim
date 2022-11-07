import { Component, OnInit } from '@angular/core';
import {UserData} from '../models/userdata';
import {StateData} from '../models/statedata'
import {LoginServiceService } from '../services/login-service.service';
import{Router} from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private _service:LoginServiceService,private _router:Router) { }
  UserdataModel:UserData=new UserData();
  StateDataModel:StateData=new StateData();
  StateDataModels:Array<StateData>=new Array<StateData>();
  ErrorMsg:string='';
  ngOnInit(): void {
    this.GetdataFromserver();
  }

  Success(input:any){
  
    this.StateDataModels=input;
  }

  GetdataFromserver(){
    this._service.GetState().subscribe(res=>{     
      //console.log(res);
      this.Success(res);
    },res=>console.log(res));
  }

  registerUser()
  {
    
    if(this.UserdataModel.memberType=="1")
    {
      this.UserdataModel.memberType="Admin";
    }
    if(this.UserdataModel.memberType=="2")
    {
      this.UserdataModel.memberType="Member";
    }

    if(this.UserdataModel.password != this.UserdataModel.conPassword)
    {
      debugger;
      this.ErrorMsg="Password and Confirm Password mismatch";
      document.getElementById('btnError')?.click();
      return;
    }
    
    var userdto = {
      firstName:this.UserdataModel.firstName,
      lastName:this.UserdataModel.lastName,
      userName: this.UserdataModel.userName,
      password: this.UserdataModel.password,
      conPassword: this.UserdataModel.conPassword,
      address: this.UserdataModel.address,
      state: this.UserdataModel.state,
      city:  this.UserdataModel.conPassword,
      email: this.UserdataModel.email,
      dateOfBirth: this.UserdataModel.dateOfBirth,
      memberType: this.UserdataModel.memberType,
    };
    
    debugger;
    this._service.registerUser(userdto).subscribe(res=>{   
      console.log(res.status);
      if(res.status!=null)
      {
        this.ErrorMsg=res.status;
        document.getElementById('btnError')?.click();
        return;
      }
      localStorage.setItem('token',res.token);
      localStorage.setItem('userid',res.userid);
      localStorage.setItem('role',res.role);
      /* this.ErrorMsg='Registration Successful';    
      document.getElementById('btnError')?.click(); */
      if(localStorage.getItem('role')=="Admin")
         this._router.navigate(['adminpage/add']);
         else
         this._router.navigate(['memberpage/add']);
    },res=>{
      console.log(res) ;
      this.ErrorMsg="Registration Unsuccessful";
      document.getElementById('btnError')?.click();

    });
  }

  login()
  {
    this._router.navigate(['login']);
  }

  hasError(typeofValidator:string,controlname:string):Boolean{
    return this.UserdataModel.formUserGroup.controls[controlname].hasError(typeofValidator);
  }

}
