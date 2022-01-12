import { Injectable } from '@angular/core';
import { CustomerProfile } from '../models/customer-profile.model';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError, of } from 'rxjs';
import { catchError, delay, retry } from 'rxjs/operators';

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

    save(saveShipper: CustomerProfile): Observable<CustomerProfile>{
        let fullUrl = this.getBaseUrl() + this.custUrl;

        let resData = this._http.post<CustomerProfile>(fullUrl, saveShipper, {
                            headers: this._header,
                        })
                        .pipe(
                            catchError(this.handleError)
                        ); 
        return resData; 
    }

    edit(saveShipper: CustomerProfile): Observable<CustomerProfile>{
        let fullUrl = this.getBaseUrl() + this.custUrl;

        let resData = this._http.put<CustomerProfile>(fullUrl, saveShipper, {
                            headers: this._header,
                        })
                        .pipe(
                            catchError(this.handleError)
                        );
        return resData;  
    }

    delete(delShipperId: number): Observable<CustomerProfile>{
        let fullUrl = this.getBaseUrl() + this.custUrl;

        let reqParams = new HttpParams();
        reqParams = reqParams.append('id', delShipperId);
        const options = {
            headers: this._header,
            params: reqParams,
            body: {
            },
          };
        let resData = this._http.delete<CustomerProfile>(fullUrl, options)
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
          'Something bad happened, please try again later.');
    }
}