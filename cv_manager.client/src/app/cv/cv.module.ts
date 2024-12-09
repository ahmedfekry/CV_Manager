import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CVListComponent } from './list/list.component';
import { CVCreateComponent } from './create/create.component';
import { CVEditComponent } from './edit/edit.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CVListComponent,
    CVCreateComponent,
    CVEditComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class CvModule { }
