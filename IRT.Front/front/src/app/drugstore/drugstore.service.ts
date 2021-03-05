import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { RequestCreateDrugstore, 
  RequestDrugstore, 
  RequestDrugstoreNeighborhood, 
  RequestUpdateDrugstore, 
  ResponseCreateDrugstore, 
  ResponseDrugstoreNeighborhood, 
  ResponseDrugstores, 
  ResponseUpdateDrugstore 
} from './drugstore.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

  export class DrugstoreService {

    private url = `${environment.apiUrl}/drugstore`;
  
    constructor(private http: HttpClient) { }  
  
    getDrugstores(request: RequestDrugstore): Observable<ResponseDrugstores[]> {      
      return this.http.get<ResponseDrugstores[]>(`${this.url}/getByName?name=${request.name}&maxResults=${request.maxResults}`).pipe(
        catchError(this.handleError)
      );
    }
  
    createDrugstore(request: RequestCreateDrugstore): Observable<ResponseCreateDrugstore>{
      return this.http.post<ResponseCreateDrugstore>(this.url, request).pipe(
        catchError(this.handleError)
      );;
    }
      
    all(): Observable<ResponseDrugstores[]>{
      return this.http.get<ResponseDrugstores[]>(`${this.url}/getAll`).pipe(
        catchError(this.handleError)
      );
    }

    getDrugstore(id: string | null): Observable<ResponseDrugstores>{
      const _url = `${this.url}/${id}`;     
      return this.http.get<ResponseDrugstores>(_url).pipe(
        catchError(this.handleError)
      );
    }

    async getDrugstoreByNeighborhood(request: RequestDrugstoreNeighborhood) {
      return await this.http.get<ResponseDrugstoreNeighborhood[]>
      (`${this.url}/GetByNeighborhood?id=${request.neighborhoodId}&flgRoundTheClock=${request.roundTheClock}`)
      .pipe(
        catchError(this.handleError)
      ).toPromise();
    }

    async getDrugstoreByNeighborhoodGraphic(idNeighborhood: string, roundTheClock: boolean) {
      return await this.http.get<ResponseDrugstoreNeighborhood[]>
      (`${this.url}/GetByNeighborhood?id=${idNeighborhood}&flgRoundTheClock=${roundTheClock}`)
      .pipe(
        catchError(this.handleError)
      ).toPromise();
    }

      
    update(id: string | null, request: RequestUpdateDrugstore): Observable<ResponseUpdateDrugstore>{
      const _url = `${this.url}/${id}`; 
      return this.http.put<ResponseUpdateDrugstore>(_url, request).pipe(
        catchError(this.handleError)
      );
    }

    delete(id: string | null): Observable<any> {
        const _url = `${this.url}/${id}`;
        return this.http.delete<any>(_url).pipe(
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