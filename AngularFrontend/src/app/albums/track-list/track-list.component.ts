import { Component, Input, OnInit } from '@angular/core';
import { Track } from 'src/app/models/track.model';

@Component({
  selector: 'app-track-list',
  templateUrl: './track-list.component.html',
  styleUrls: ['./track-list.component.css']
})
export class TrackListComponent implements OnInit {

  constructor() { }

  @Input() tracks: Track[];
  trackMinutesLength:number[]=[];
  trackSecondsLength:number[]=[];
  ngOnInit(): void {
    if(this.tracks){
      for(var i=0; i<this.tracks.length;i++ ){
        this.trackMinutesLength[i]=Math.floor(this.tracks[i].length / 60);//get minutes length from seconds
        this.trackSecondsLength[i]=this.tracks[i].length - this.trackMinutesLength[i] * 60;//get remaining seconds
      } 
    }
  }

}
