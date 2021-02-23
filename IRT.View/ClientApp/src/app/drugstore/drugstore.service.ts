import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })

  export class DrugstoreService {

    private url = 'https://localhost:44384/api/drugstore';
  
    constructor(private http: HttpClient) { }  
  
    /* getDrugstore(name: string | null, maxResults: number): Observable<ResponseDrugstore>{
      //let params = new HttpParams({name, max});      
      return this.http.get<ResponseDrugstore>(this.url, {
        params: {
          name: 'id1234',
          maxResults: '5'
        }
      });
    } */
  
    /* createNeighBorhood(request: RequestCreate): Observable<ResponseCreate>{
      return this.http.post<ResponseCreate>(this.url, request);
    } */
  
    /* getById
    getNeighborhood(id: string): Observable<ResponseNeighborhood>{
      const _url = `${this.url}/${id}`;     
      return this.http.get<ResponseDrugstore>(_url);
    } */
  
    /* update
    update(id: string, request: RequestUpdate): Observable<ResponseUpdate>{
      const _url = `${this.url}/${id}`; 
      return this.http.put<ResponseUpdate>(this.url, request);
    } */

    /* delete(id: string): Observable<any> {
        const _url = `${this.url}/${id}`;
        return this.http.delete<any>(_url);
    } */
  
  
  }