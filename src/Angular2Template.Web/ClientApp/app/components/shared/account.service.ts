
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';

import { AccountSummary } from './account-summary.type';
import { AccountDetail } from './account-detail.type';

@Injectable()
export class AccountService {

    private originUrl: string

    constructor(private http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.originUrl = originUrl;
    }

    getAccountSummaries() {
        return this.http.get(this.originUrl + '/api/Bank/GetAccountSummaries')
            .map(response => response.json() as AccountSummary[])
            .toPromise();
    }

    getAccountDetail(id: string) {
        return this.http.get(this.originUrl + `/api/Bank/GetAccountDetail/${id}`) // note string interpolation
            .map(response => response.json() as AccountDetail)
            .toPromise();
    }
}
