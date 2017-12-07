import { Injectable, Inject } from '@angular/core';
import { HttpParams, HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HistoryService {

    constructor(private _http: HttpClient) { }

    public GetHistory(optionId: Number): Observable<any> {
        return this._http.get('/api/History/GetHistory?optionId=' + optionId);
    }
}