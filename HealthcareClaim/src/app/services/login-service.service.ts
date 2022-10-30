import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {
  _stateUrl="https://localhost:44308/api/gateway/State/GetStateAll";
  _loginUrl="https://localhost:44308/api/gateway/Login/loginuser";
  _registerUrl="https://localhost:44308/api/gateway/Login/register";
  constructor(private http:HttpClient,private _router:Router) { }

  GetState()
  {
    return this.http.get(this._stateUrl)
  }
  loginUser(login:any)
  {
    
    return this.http.post<any>(this._loginUrl,login);
  }
  registerUser(register:any)
  {
    debugger;
    return this.http.post<any>(this._registerUrl,register);
  }
  getToken()
  {
    return localStorage.getItem('token');
  }
  logingIn(){
    return !!localStorage.getItem('token');
  }
  logotUser()
  {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    localStorage.removeItem('userid');
    this._router.navigate(['']);
  }

}
