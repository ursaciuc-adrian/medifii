import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class PharmacyService {
    private pharmacyEndpoint='api/pharmacy';
    private pharmacies
    constructor(private http: HttpClient) {

    }

    getAllPharmacies() {
        return new Promise((resolve, reject) => {
            if (this.pharmacies) {
                resolve(this.pharmacies);
            }
            this.http.get(`${this.pharmacyEndpoint}/get`).toPromise().then(
                (rsp) => {
                    this.pharmacies = rsp;
                    resolve(this.pharmacies);
                },
                (err) => {
                    console.error(err);
                    resolve(null);
                }
            );
        });
    }
}
