export class Track{
    constructor(
        public id: number,
        public title: string,
        public trackNumber: number,
        public length: number,
        public artistName: string,
        public releaseYear: number,
        public albumID: number
    ){}
}