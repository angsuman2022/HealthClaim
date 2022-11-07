import { Component, OnInit } from '@angular/core';
import {ClaimData} from '../models/claimdata';
import{Router} from '@angular/router';
import{MbrclmData} from '../models/Mbrclmdata';
import{MemberServiceService} from '../services/member-service.service';
import{ClaimServiceService} from '../services/claim-service.service';


@Component({
  selector: 'app-memberpage',
  templateUrl: './memberpage.component.html',
  styleUrls: ['./memberpage.component.css']
})
export class MemberpageComponent implements OnInit {

  constructor(private _service:MemberServiceService,private _claimServ:ClaimServiceService) { }
  MemberClaimModel: MbrclmData = new MbrclmData();
  MemberClaimModels: Array<MbrclmData> = new Array<MbrclmData>();
  ClaimdataModel:ClaimData=new ClaimData();
  ErrorMsg:string='';
  ngOnInit(): void {
    this.GetdataFromserver();
  }

  GetdataFromserver(){
    var user=this._service.getuserId();
    this._service.getMemberDetails(Number(user)).subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res));
  }
  Success(input:any){
    
    this.MemberClaimModels=input;
  }

  ClaimSave() {
    var user=this._service.getuserId();
    if(this.ClaimdataModel.claimType=="1")
    {
      this.ClaimdataModel.claimType="Vision"
    }
    if(this.ClaimdataModel.claimType=="2")
    {
      this.ClaimdataModel.claimType="Dental"
    }
    if(this.ClaimdataModel.claimType=="3")
    {
      this.ClaimdataModel.claimType="Medical"
    }
    
    var claimdata = {
      claimType:this.ClaimdataModel.claimType,
      claimAmount:this.ClaimdataModel.claimAmount,
      claimDate: this.ClaimdataModel.claimDate,
      remarks: this.ClaimdataModel.remarks,
      memberId:Number(user)
      
    };
    
    console.log(claimdata);

    this._claimServ.AddClaim(claimdata).subscribe(res=>{   
      
      this.ErrorMsg=res.status;
      document.getElementById('btnError')?.click();
      this.GetdataFromserver();
     
  },res=>{
    console.log(res) ;
    this.ErrorMsg="Claim Submission Unsuccessful";
    document.getElementById('btnError')?.click();

  });

  
    
  }

}
