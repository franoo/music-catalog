import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Album } from 'src/app/models/album.model';
import { AlbumService } from 'src/app/services/album.service';

@Component({
  selector: 'app-album-details',
  templateUrl: './album-details.component.html',
  styleUrls: ['./album-details.component.css']
})
export class AlbumDetailsComponent implements OnInit {

  constructor(
    private albumService:AlbumService, 
    private route: ActivatedRoute,
    private router: Router)  {
   }

  album: Album;
  tracksAmount:number;
  id:number;

  isSmallScreen=false;

  ngOnInit(): void {
    this.route.params.subscribe(params =>{
      this.id = params['id'];
    });
    this.albumService.getAlbum(this.id).subscribe((data:Album)=>{
      this.album=data;
      this.tracksAmount = this.album.tracks.length;
    });
  }

}
