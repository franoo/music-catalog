import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './authentication/login/login.component';
import { AlbumComponent } from './albums/album/album.component';
import { AlbumsListComponent } from './albums/albums-list/albums-list.component';
import { AuthService } from './services/auth.service';
import { AuthInterceptor } from './services/auth.interceptor';
import { AlbumDetailsComponent } from './albums/album-details/album-details.component';
import { TrackListComponent } from './albums/track-list/track-list.component';
import { FilterComponent } from './albums/filter/filter.component';
import { HeaderComponent } from './header/header.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AlbumComponent,
    AlbumsListComponent,
    AlbumDetailsComponent,
    TrackListComponent,
    FilterComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [AuthService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
