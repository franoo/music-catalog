import { Component, OnInit } from '@angular/core';
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

  ngOnInit(): void {
    this.albumService.getAlbums().subscribe((data:Album[])=>{
      this.albums = data;
      console.log(this.albums);
    })
  }
}
