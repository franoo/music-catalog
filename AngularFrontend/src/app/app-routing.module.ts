import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlbumDetailsComponent } from './albums/album-details/album-details.component';
import { AlbumsListComponent } from './albums/albums-list/albums-list.component';
import { LoginComponent } from './authentication/login/login.component';

const routes: Routes = [
  {
    path:'login', component: LoginComponent,
  },
  {    
    path:'albums', component: AlbumsListComponent, children:[]
  },
  {
    path:'albums/:id', component:AlbumDetailsComponent
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
