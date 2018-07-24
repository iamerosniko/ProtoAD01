import 'rxjs/add/operator/toPromise';
import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { ClientApiSettings } from './client.services'
@Injectable()
export class EnvironmentSvc {
    private headers = new Headers({
        'Content-Type': 'application/json',
        'Cache-Control': 'no-cache',
        'Pragma': 'no-cache',
        'Expires': 'Sat, 01 Jan 2000 00:00:00 GMT'
    });

    constructor(private http: Http){}

    getBWURL(): Promise<EnvInfo> {
        var apiUrl = ClientApiSettings.GETCLIENTAPIURL("getBW");
        return this.http
            .post(apiUrl, {headers: this.headers})
            .toPromise()
            .then(response => response.json())
            .catch();
    }
}

export interface EnvInfo {
    URL?:string
}