import {NgForm,FormGroup,Validators,FormBuilder,FormControl} from '@angular/forms'
export class ClaimData{
    claimId:number=0;
    claimType:string='';
    claimAmount:number=0;
    claimDate:string='';
    memberId:number=0;
    remarks:string='';
    formUserGroup:FormGroup;
    constructor(){
        
        var _builder=new FormBuilder();
        this.formUserGroup=_builder.group({});     
        this.formUserGroup.addControl("ClaimType",new FormControl('',Validators.required));       
        this.formUserGroup.addControl("ClaimAmount",new FormControl('',Validators.required));      
        this.formUserGroup.addControl("Remarks",new FormControl('',Validators.required));
        this.formUserGroup.addControl("Claimdate",new FormControl('',Validators.required));
        
    }
    }