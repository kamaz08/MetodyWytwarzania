import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class OptionService {

    constructor(private _http: HttpClient) { }

    public GetOptions(websiteId: Number): Observable<any> {
        return this._http.get('/api/Options/GetOptions?websiteId=' + websiteId);
    }

    public GetOption(id: Number): Observable<any> {
        return this._http.get('/api/Options/GetOption?id=' + id);
    }
}