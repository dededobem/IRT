import { Component, OnInit } from '@angular/core';
import { ResponseNeighborhoods } from '../neighborhood.model';
import { NeighborhoodService } from '../neighborhood.service';

@Component({
  selector: 'app-list-neighborhood',
  templateUrl: './list-neighborhood.component.html',
  styleUrls: ['./list-neighborhood.component.css']
})
export class ListNeighborhoodComponent implements OnInit {

  responseNeighborhoods: ResponseNeighborhoods;
  
  constructor(private neighborhoodService: NeighborhoodService) {}

  ngOnInit() {
    /* this.neighborhoodService.getNeighborhoods("Pituba", 2).
      subscribe(res => 
        this.responseNeighborhoods = res
    ); */
  }

}
