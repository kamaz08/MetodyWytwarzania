import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class WebsiteService {

    constructor(private _http: HttpClient) { }

    public GetWebsite(): Observable<any> {
        return this._http.get('/api/Website/GetWebsite');
    }

    public GetListWebstite(): Observable<any> {
        return this._http.get('/api/Website/GetListWebstite');
    }

}