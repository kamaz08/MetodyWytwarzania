import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UserService {

    constructor(private _http: HttpClient) { }

    public Subscribe(optionId: Number, email: String): Observable<any> {
        return this._http.get('/api/User/Subscribe?optionId=' + optionId + '&email='+email);
    }

    public GetOption(id: Number): Observable<any> {
        return this._http.get('/api/Options/GetOption?id=' + id);
    }
}