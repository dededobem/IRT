import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Neighborhood, RequestCreate, ResponseCreate, ResponseNeighborhoods } from './neighborhood.model';

@Injectable({
  providedIn: 'root'
})
export class NeighborhoodService {

  private url = 'https://localhost:44384/api/neighborhood';

  constructor(private http: HttpClient) { }  

  getNeighborhoods(name: string | null, maxResults: number): Observable<ResponseNeighborhoods>{
    //let params = new HttpParams({name, max});      
    return this.http.get<ResponseNeighborhoods>(this.url, {
      params: {
        name: 'Pituba',
        maxResults: '6'
      }
    });
  }

  createNeighBorhood(request: RequestCreate): Observable<ResponseCreate>{
    return this.http.post<ResponseCreate>(this.url, request);
  }

  /* getById
  getNeighborhood(id: string): Observable<ResponseNeighborhood>{
    const _url = `${this.url}/${id}`;     
    return this.http.get<ResponseNeighborhoods>(_url);
  } */

  /* update
  update(id: string, request: RequestUpdate): Observable<ResponseUpdate>{
    const _url = `${this.url}/${id}`; 
    return this.http.put<ResponseUpdate>(this.url, request);
  } */


}
