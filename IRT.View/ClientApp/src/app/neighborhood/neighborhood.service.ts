import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Neighborhood, ResponseNeighborhoods } from './neighborhood.model';

@Injectable({
  providedIn: 'root'
})
export class NeighborhoodService {

  private url = 'https://localhost:44384/api/neighborhood';

  constructor(private http: HttpClient) { }

  getNeighborhood(): Observable<ResponseNeighborhoods>{
    return this.http.get<ResponseNeighborhoods>(this.url);
  }
}
