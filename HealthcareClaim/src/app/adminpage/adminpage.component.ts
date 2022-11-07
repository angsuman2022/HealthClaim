import { Component, OnInit } from '@angular/core';
import {MemberData} from '../models/memberdata';
import {StateData} from '../models/statedata';
import {ClaimData} from '../models/claimdata';
import { PhisicianData} from '../models/physiandata';
import{Router} from '@angular/router';
import{MbrclmData} from '../models/Mbrclmdata';
import{MemberServiceService} from '../services/member-service.service';
import{ClaimServiceService} from '../services/claim-service.service';
import { MaxLengthValidator } from '@angular/forms';

@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.css']
})
export class AdminpageComponent implements OnInit {

  constructor(private _service:MemberServiceService,private _claimServ:ClaimServiceService) { }
  MemberClaimModel: MbrclmData = new MbrclmData();
  MemberClaimModels: Array<MbrclmData> = new Array<MbrclmData>();
  UserdataModel:MemberData=new MemberData();
  StateDataModel:StateData=new StateData();
  StateDataModels:Array<StateData>=new Array<StateData>();
  ClaimdataModel:ClaimData=new ClaimData();
  PhysicianDataModels:Array<PhisicianData>=new Array<PhisicianData>();
  MemberSearchModel:MbrclmData = new MbrclmData();
  ErrorMsg:string='';
  ngOnInit(): void {
    this.GetDataFromServer();
  }

  GetDataFromServer() {
    this._service.GetMemberDet().subscribe(res => this.Success(res), res => console.log(res));
    this._service.GetState().subscribe(res=> this.SuccessState(res),res=>console.log(res));
    this._service.GetPhysician().subscribe(res=> this.SuccessPhysician(res),res=>console.log(res));

  }

  Success(input: any) {
    //console.log(input);
    this.MemberClaimModels = input;
  }
  SuccessState(input: any) {
    //console.log(input);
    this.StateDataModels = input;
  }
  SuccessPhysician(input: any) {
    //console.log(input);
    this.PhysicianDataModels = input;
  }
  SearchMember()
  {

    if(this.MemberSearchModel.firstName!="" || this.MemberSearchModel.lastName!="")
    {
      if(this.MemberSearchModel.lastName=="" || this.MemberSearchModel.firstName=="")
      {
          this.ErrorMsg="Both first and last name is required.";
          document.getElementById('btnError')?.click();
          return;
      }
    }

    var searchdto = {
      memberId: Number(this.MemberSearchModel.memberId),
      firstName:this.MemberSearchModel.firstName,
      lastName:this.MemberSearchModel.lastName,
      physianId:0,
      physicianName:this.MemberSearchModel.physicianName,
      claimId: 0,
      claimAmount: 0,
      claimDate: "",
      
    };
   
    this._service.SearchMember(searchdto).subscribe(res=> 
      {
        this.SuccessSearch(res)
        //console.log(res);
      },res=>console.log(res));

  }
  SuccessSearch(input: any) {
    //console.log(input);
    this.MemberClaimModels = input;
  }
  AddMember()
  {

    if(this.UserdataModel.password != this.UserdataModel.conPassword)
    {
      
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
      
    };
    

    this._service.AddMember(userdto).subscribe(res=>{   
      
        this.ErrorMsg=res.status;
        document.getElementById('btnError')?.click();
        this.GetDataFromServer();
       
    },res=>{
      console.log(res) ;
      this.ErrorMsg="Add Member Unsuccessful";
      document.getElementById('btnError')?.click();

    });
  }
  ClaimClick(input: any) {   
    this.MemberClaimModel = input;
    this.ClaimdataModel= new ClaimData();
    this.ClaimdataModel.memberId=Number(this.MemberClaimModel.memberId);
    //console.log(this.ClaimdataModel);
    document.getElementById('btnAddClaim')?.click();
  }

  Clear()
  {
    this.MemberSearchModel=new MbrclmData();
    this.GetDataFromServer();
  }

  ClaimSave() {
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
      memberId:this.ClaimdataModel.memberId
      
    };
    
    console.log(claimdata);

    this._claimServ.AddClaim(claimdata).subscribe(res=>{   
      
      this.ErrorMsg=res.status;
      document.getElementById('btnError')?.click();
     // this.GetDataFromServer();
     this.SearchMember();
     
  },res=>{
    console.log(res) ;
    this.ErrorMsg="Claim Submission Unsuccessful";
    document.getElementById('btnError')?.click();

  });
    
  }

  hasError(typeofValidator:string,controlname:string):Boolean{
    return this.UserdataModel.formUserGroup.controls[controlname].hasError(typeofValidator);
  }

  /* hasClaimError(typeofValidator:string,controlname:string):Boolean{
    return this.ClaimdataModel.formUserGroup.controls[controlname].hasError(typeofValidator);
  } */

}
