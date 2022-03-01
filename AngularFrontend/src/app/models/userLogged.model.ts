export class UserLogged{
    constructor(
        public id: number,
        public username: string,
        public jwtToken: string
    ){}
}