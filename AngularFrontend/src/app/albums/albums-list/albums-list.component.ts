import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Album } from 'src/app/models/album.model';
import { AlbumService } from 'src/app/services/album.service';

@Component({
  selector: 'app-albums-list',
  templateUrl: './albums-list.component.html',
  styleUrls: ['./albums-list.component.css']
})
export class AlbumsListComponent implements OnInit {

  constructor(private albumService: AlbumService) { }

  albums: Album[]=[];
  selectedAlbum?: Album;
  albumListChangeSubscription: Subscription;

  ngOnInit(): void {
    this.albumService.getAlbums().subscribe((data:Album[])=>{
      this.albums = data;
      console.log(this.albums);
    })
    this.albumListChangeSubscription=this.albumService.albumListChanged.subscribe(
      (albums:Album[])=>{
        console.log("new list came");
        this.albums=albums;
      }
    )
  }

  onArtistSelected(index: number){
    console.log(index);
  }

  ngOnDestroy(){
    this.albumListChangeSubscription.unsubscribe();
}
}
