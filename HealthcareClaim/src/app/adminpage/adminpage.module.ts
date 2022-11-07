import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router'
import { AdminpageComponent } from './adminpage.component';
import { adminpageroutes } from '../routing/adminpageroutes';
import { GridUIModule } from '../utilites/grid-ui/grid-ui.module';
import { MemberServiceService } from '../services/member-service.service';

@NgModule({
  declarations: [
  
    AdminpageComponent,
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(adminpageroutes),
    GridUIModule
  ],
  providers: [MemberServiceService],
  bootstrap: [AdminpageComponent]
})
export class AdminpageModule { }
