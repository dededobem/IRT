import { Component, OnInit } from '@angular/core';
import { Neighborhood, ResponseNeighborhoods } from './neighborhood.model';
import { NeighborhoodService } from './neighborhood.service';

@Component({
  selector: 'app-neighborhood',
  templateUrl: './neighborhood.component.html',
  styleUrls: ['./neighborhood.component.css']
})
export class NeighborhoodComponent implements OnInit {

  responseNeighborhoods: ResponseNeighborhoods;
  
  constructor(private neighborhoodService: NeighborhoodService) {}

  ngOnInit() {
    this.neighborhoodService.getNeighborhood().
      subscribe(res => 
        this.responseNeighborhoods = res
    );
  }

}
