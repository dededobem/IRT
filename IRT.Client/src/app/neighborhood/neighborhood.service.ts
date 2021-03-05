import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { RequestNeighborhood, RequestCreate, ResponseCreate, ResponseNeighborhoods } from './neighborhood.model';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NeighborhoodService {

  private url = 'https://localhost:5001/api';

  constructor(private http: HttpClient) { }  

  getNeighborhoods(request: RequestNeighborhood): Observable<ResponseNeighborhoods>{ 
      const params = Object.keys(request)
        .map((key) => key + "=" + (request[key] || ""))
        .join("&");
      return this.http.get<ResponseNeighborhoods>(`${this.url}/getByName?${params}`).pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  createNeighBorhood(request: RequestCreate): Observable<ResponseCreate>{
    return this.http.post<ResponseCreate>(`${this.url}/neighborhood`, request).pipe(
      retry(1),
      catchError(this.handleError)
    );
  }

  all(): Observable<ResponseNeighborhoods>{
    return this.http.get<ResponseNeighborhoods>(`${this.url}/getAll`).pipe(
      retry(1),
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
