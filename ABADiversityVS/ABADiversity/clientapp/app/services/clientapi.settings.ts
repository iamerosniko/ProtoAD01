export class ClientApiSettings {
    private static CURRENT_URL = "http://localhost:50000/api/"
    private static API_URL = "http://localhost:60000/api/"

    public static GETAPIURL(controller:string):string{
        return this.API_URL+controller;
    }

    public static GETCLIENTAPIURL(controller:string):string{
        return this.CURRENT_URL+controller;
    }

    public static HANDLEERROR(error : any):Promise<any>{
        console.error('An error occured',error);
        return Promise.reject(error.message || error);
    }
}
