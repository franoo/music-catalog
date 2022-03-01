import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlbumsListComponent } from './albums/albums-list/albums-list.component';
import { LoginComponent } from './authentication/login/login.component';

const routes: Routes = [
  {
    path:'login', component: LoginComponent,
  },
  {    
    path:'albums', component: AlbumsListComponent
  },
  {
    path:'', redirectTo: '/login', pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
