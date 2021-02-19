import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseNeighborhoods } from './neighborhood.model';

@Injectable({
  providedIn: 'root'
})
export class NeighborhoodService {

  private url = 'https://localhost:44384/api/neighborhood';

  constructor() { }

  getNeighborhood(): Observable<ResponseNeighborhoods>{
    
  }
}
