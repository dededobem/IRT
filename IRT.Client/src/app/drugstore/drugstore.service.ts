import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { RequestCreateDrugstore, RequestDrugstore, RequestUpdateDrugstore, ResponseCreateDrugstore, ResponseDrugstores, ResponseUpdateDrugstore } from './drugstore.model';

@Injectable({
    providedIn: 'root'
  })

  export class DrugstoreService {

    private url = 'https://localhost:5001/api/drugstore';
  
    constructor(private http: HttpClient) { }  
  
    getDrugstores(request: RequestDrugstore): Observable<ResponseDrugstores[]> {
      const params = Object.keys(request)
        .map((key) => key + "=" + (request[key] || ""))
        .join("&");
      return this.http.get<ResponseDrugstores[]>(`${this.url}?${params}`).pipe(
        catchError(this.handleError)
      );
    }
  
    createDrugstore(request: RequestCreateDrugstore): Observable<ResponseCreateDrugstore>{
      return this.http.post<ResponseCreateDrugstore>(this.url, request);
    }
      
    getDrugstore(id: string): Observable<ResponseUpdateDrugstore>{
      const _url = `${this.url}/${id}`;     
      return this.http.get<ResponseUpdateDrugstore>(_url).pipe(
        catchError(this.handleError)
      );
    }
      
    update(id: string, request: RequestUpdateDrugstore): Observable<ResponseUpdateDrugstore>{
      const _url = `${this.url}/${id}`; 
      return this.http.put<ResponseUpdateDrugstore>(_url, request).pipe(
        catchError(this.handleError)
      );
    }

    delete(id: string): Observable<any> {
        const _url = `${this.url}/${id}`;
        return this.http.delete<any>(_url).pipe(
          catchError(this.handleError)
        );
    }

    handleError(error) {
      let errorMessage = ''; 
      if (error.error instanceof ErrorEvent) { 
        errorMessage = `Error: ${error.error.message}`; 
      } else { 
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`; 
      } 
      window.alert(errorMessage); 
      return throwError(errorMessage); 
    }  
  
  }