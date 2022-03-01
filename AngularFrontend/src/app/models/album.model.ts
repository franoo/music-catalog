import { Track } from "./track.model";

export class Album{
    constructor(
        public albumID: number,
        public title: string,
        public artistName: string,
        public version: string,
        public releaseYear: number,
        public userID: number,
        public pictureURL: string,
        public tracks: Track[]
    ){}
}