import {NgForm,FormGroup,Validators,FormBuilder,FormControl} from '@angular/forms'
export class UserData{
   firstName:string='';
   lastName: string='';
   userName: string='';
   password: string='';
   conPassword: string='';
   address: string='';
   state: string='';
   city:string='';
   email: string='';
   dateOfBirth: string='';
   memberType: string='';  
    formUserGroup:FormGroup;
    constructor(){
        var _builder=new FormBuilder();
        this.formUserGroup=_builder.group({});
        /* this.formUserGroup.addControl("FirstNameControl",new FormControl('',Validators.required)); */
        /* this.formUserGroup.addControl("LastNameControl",new FormControl('',Validators.required)); */
        this.formUserGroup.addControl("UserNameControl",new FormControl('',Validators.required));
        /* this.formUserGroup.addControl("Password1Control",new FormControl('',Validators.required)); */
        this.formUserGroup.addControl("Password2Control",new FormControl('',Validators.required));      
        this.formUserGroup.addControl("roleControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("AddressControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("StateControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("CityControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("DOBControl",new FormControl('',Validators.required));
        var validationcollection=[];
        validationcollection.push(Validators.required);        
        validationcollection.push(Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$"));
        this.formUserGroup.addControl("EmailControl",new FormControl('',Validators.compose(validationcollection)));
        var passValCollection=[];
        passValCollection.push(Validators.required);
        passValCollection.push(Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$/));
        this.formUserGroup.addControl("Password1Control",new FormControl('',Validators.compose(passValCollection)));
        var firstNameCollection=[];
        firstNameCollection.push(Validators.required);
        firstNameCollection.push(Validators.pattern("^[a-zA-Z0-9]{5,20}$"));
        this.formUserGroup.addControl("FirstNameControl",new FormControl('',Validators.compose(firstNameCollection)));
        var lastNameCollection=[];
        lastNameCollection.push(Validators.required);
        lastNameCollection.push(Validators.pattern("^[a-zA-Z0-9]{5,20}$"));
        this.formUserGroup.addControl("LastNameControl",new FormControl('',Validators.compose(lastNameCollection)));

    }
}