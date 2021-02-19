import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-neighborhood',
  templateUrl: './neighborhood.component.html',
  styleUrls: ['./neighborhood.component.css']
})
export class NeighborhoodComponent implements OnInit {

  /* public neighborhoods: Neighborhood[];

  url = 'https://localhost:44384/api/neighborhood';
  
  constructor(http: HttpClient) {
    http.get<Neighborhood[]>(this.url).subscribe(result => {
      this.neighborhoods = result;
    }, error => console.error(error));
  } */

  ngOnInit(): void {
    
  }

}
