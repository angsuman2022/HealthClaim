import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ClaimServiceService {
  _ClaimAddUrl="https://localhost:44308/api/gateway/Claim/ClaimAdd"
  constructor(private http:HttpClient) { }

  AddClaim(input:any)
  {
    debugger;
    return this.http.post<any>(this._ClaimAddUrl,input);
  }
}
