import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { 
  RequestNeighborhood, 
  RequestCreate, 
  ResponseCreate, 
  Neighborhood 
} from './neighborhood.model';
import { catchError } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class NeighborhoodService {

  private url = `${environment.apiUrl}/neighborhood`;

  constructor(private http: HttpClient) { }  

  getNeighborhoods(request: RequestNeighborhood): Observable<Neighborhood[]>{       
      return this.http
        .get<Neighborhood[]>(`${this.url}/getByName?name=${request.name}&maxResults=${request.maxResults}`).pipe(      
      catchError(this.handleError)
    );
  }

  createNeighBorhood(request: RequestCreate): Observable<ResponseCreate>{
    return this.http.post<ResponseCreate>(`${this.url}`, request).pipe(      
      catchError(this.handleError)
    );
  }

  all(): Observable<Neighborhood[]>{
    return this.http.get<Neighborhood[]>(`${this.url}/getAll`).pipe(      
      catchError(this.handleError)
    );
  }

  handleError(error: any) {
    let errorMessage = ''; 
    if (error.error instanceof ErrorEvent) { 
      errorMessage = `Error: ${error.error}`; 
    } else { 
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.error.Title}`; 
    } 
    Swal.fire('Atenção', `${error.error.Title}`, 'warning');
    return throwError(errorMessage); 
  }  
  
}
