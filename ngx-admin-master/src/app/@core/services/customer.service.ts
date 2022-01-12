import { Injectable } from '@angular/core';
import { CustomerProfile } from '../models/customer-profile.model';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class CustomerService{
    private customerProfiles: CustomerProfile[] = [] as CustomerProfile[];
    private _header: HttpHeaders = new HttpHeaders({
        'Content-Type': 'application/json',
    });
    private custUrl = "api/Customer/Profile";

    constructor(
        private _http: HttpClient
        ){

    }

    getBaseUrl() {  
        return "https://localhost:44367/";
     }  

    getCustomerProfile(): Observable<CustomerProfile[]>{
        let fullUrl = this.getBaseUrl() + this.custUrl;
        let resData = this._http.get<CustomerProfile[]>(fullUrl, { headers: this._header })
                        .pipe(
                            catchError(this.handleError)
                        );        
        return resData;
    }

    save(saveCustomerProfile: CustomerProfile): Observable<any>{
        let fullUrl = this.getBaseUrl() + this.custUrl;
        let resData = this._http.post(fullUrl, saveCustomerProfile, { headers: this._header })
                        .pipe(
                            catchError(this.handleError)
                        );          
        return resData; 
    }

    edit(saveShipper: CustomerProfile): Observable<any>{
        let fullUrl = this.getBaseUrl() + this.custUrl;
        let resData = this._http.put(fullUrl, saveShipper, { headers: this._header })
                        .pipe(
                            catchError(this.handleError)
                        );
        return resData;  
    }

    delete(delId: number): Observable<any>{
        let fullUrl = this.getBaseUrl() + this.custUrl + "/" + delId;
        let resData = this._http.delete(fullUrl)
                        .pipe(
                            catchError(this.handleError)
                        ); 
        return resData; 
    }

    private handleError(error: HttpErrorResponse) {
        if (error.status === 0) {
          console.error('An error occurred:', error.error);
        } else {
          console.error(
            `Backend returned code ${error.status}, body was: `, error.error);
        }
        
        return throwError(
          'Something bad happened, please try again later.' + JSON.stringify(error.error));
    }
}