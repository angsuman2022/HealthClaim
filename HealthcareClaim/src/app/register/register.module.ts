import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router'
import { RegisterComponent } from './register.component';

//import { loginroutes  } from '../routing/loginroutes';


@NgModule({
  declarations: [
  
    RegisterComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    //RouterModule.forChild(loginroutes)
  ],
  providers: [],
  bootstrap: [RegisterComponent]
})
export class RegisterModule { }
