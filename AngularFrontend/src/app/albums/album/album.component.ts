import { Component, Input, OnInit } from '@angular/core';
import { Album } from 'src/app/models/album.model';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.css']
})
export class AlbumComponent implements OnInit {

  constructor() { }

  @Input() album: Album;
  tracksAmount:number
  ngOnInit(): void {
    this.tracksAmount = this.album.tracks.length;
  }

}
