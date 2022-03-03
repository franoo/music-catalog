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
  trackSecondsLength:string[]=[];
  ngOnInit(): void {
    if(this.tracks){
      var secondsNumber:number[]=[];
      for(var i=0; i<this.tracks.length;i++ ){
        this.trackMinutesLength[i]=Math.floor(this.tracks[i].length / 60);//get minutes length from seconds
        secondsNumber[i]=this.tracks[i].length - this.trackMinutesLength[i] * 60;//get remaining seconds
        this.trackSecondsLength[i] = secondsNumber[i].toLocaleString('en-US', {//digit formatting - adding 0 before one-digit number in track seconds length
          minimumIntegerDigits: 2,
          useGrouping: false
        });

      } 
    }
  }

}
