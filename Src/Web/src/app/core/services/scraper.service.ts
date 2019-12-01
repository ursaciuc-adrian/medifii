import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ScraperService {
    private meds;
    constructor(private http: HttpClient) {

    }

    getMeds() {
        return new Promise((resolve, reject) => {
            if (this.meds) {
                resolve(this.meds);
            }
            this.http.get('http://localhost:7020/scraper').toPromise().then(
                (rsp) => {
                    this.meds = rsp;
                    resolve(this.meds);
                },
                (err) => {
                    console.error(err);
                    resolve(null);
                }
            )
        })
    }
}