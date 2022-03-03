import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { SelectorMatcher } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { BehaviorSubject, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Album } from '../models/album.model';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  constructor(private http: HttpClient, authService: AuthService) { }

  getAlbums(){
    return this.http.get<Album[]>('http://localhost:5000/api/albums')
      .pipe(catchError(this.handleError));
  }
  getAlbum(id: number){
    return this.http.get<Album>('http://localhost:5000/api/albums/'+id)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
