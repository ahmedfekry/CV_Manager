import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CVListComponent } from './cv/list/list.component';
import { CVCreateComponent } from './cv/create/create.component';
import { CVEditComponent } from './cv/edit/edit.component';


const routes: Routes = [
  { path: 'cv', component: CVListComponent },
  { path: 'cv/create', component: CVCreateComponent },
  { path: 'cv/edit/:id', component: CVEditComponent },
  { path: '', redirectTo: 'cv', pathMatch: 'full' },
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
