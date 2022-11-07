import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NewgridUiComponent } from './newgrid-ui.component';

@NgModule({
  declarations: [
    NewgridUiComponent
  ],
  imports: [CommonModule],
  exports:[NewgridUiComponent,CommonModule]
})
export class NewgridUIModule { }