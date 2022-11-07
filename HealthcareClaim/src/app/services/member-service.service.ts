import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class MemberServiceService {
  _MemberDetUrl="https://localhost:44308/api/gateway/Member/GetMemberClaim";
  _stateUrl="https://localhost:44308/api/gateway/State/GetStateAll";
  _MemberAddUrl="https://localhost:44308/api/gateway/Member/MemberAdd";
  _PhysicianUrl="https://localhost:44308/api/gateway/Member/GetPhysicianAll";
  _Membersearch="https://localhost:44308/api/gateway/Member/SearchClaim";
  _MemberdetailsUrl="https://localhost:44308/api/gateway/Member/GetMemClaim?mId=";
  constructor(private http:HttpClient,private _router:Router) { }

  GetMemberDet()
  {
    return this.http.get(this._MemberDetUrl)
  }
  GetState()
  {
    return this.http.get(this._stateUrl)
  }

  GetPhysician()
  {
    return this.http.get(this._PhysicianUrl)
  }
  AddMember(input:any)
  {
    
    return this.http.post<any>(this._MemberAddUrl,input);
  }
  SearchMember(input:any)
  {
   
    return this.http.post<any>(this._Membersearch,input);
  }

  getMemberDetails(id:any)
  {
    return this.http.get(this._MemberdetailsUrl+id);
  }

  getuserId()
  {
    return localStorage.getItem('userid');
  }
}
