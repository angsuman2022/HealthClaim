import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router'
import { MemberpageComponent } from './memberpage.component';
import { memberpageroutes } from '../routing/memberpageroutes';
import { NewgridUIModule } from '../utility/newgrid-ui/newgrid-ui.module';
import { MemberServiceService } from '../services/member-service.service';

@NgModule({
  declarations: [
  
    MemberpageComponent,
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(memberpageroutes),
    NewgridUIModule
  ],
  providers: [MemberServiceService],
  bootstrap: [MemberpageComponent]
})
export class MemberpageModule { }
