// export interface CurrentUser {
//     UserID ?:string,
//     FirstName :string,
//     LastName :string,
//     Urls ?:string,
//     IdS ?:string,
//     Name ?:string,
//     Roles ?:string[],
// }
export class CurrentUser {
    constructor(
        public UserID :string,
    public FirstName :string,
    public LastName :string,
    public Urls ?:string,
    public IdS ?:string,
    public Name ?:string,
    public Roles ?:string[] 
    ){

    }       
}
    