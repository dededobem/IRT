import { Component, OnInit } from '@angular/core';
import { RequestNeighborhood, ResponseNeighborhoods } from '../neighborhood.model';
import { NeighborhoodService } from '../neighborhood.service';

@Component({
  selector: 'app-list-neighborhood',
  templateUrl: './list-neighborhood.component.html',
  styleUrls: ['./list-neighborhood.component.css']
})
export class ListNeighborhoodComponent implements OnInit {

  requestNeighborhood: RequestNeighborhood = {
    name: '',
    maxResults: 0
  };
  responseNeighborhoods: ResponseNeighborhoods;
  
  constructor(private neighborhoodService: NeighborhoodService) {}

  ngOnInit() {    
    this.neighborhoodService.all().subscribe(res =>{
      this.responseNeighborhoods = res;
    });
  }

  search() {
    this.neighborhoodService.getNeighborhoods(this.requestNeighborhood).subscribe(res => {
        this.responseNeighborhoods = res;
        console.log(res);
      }
    );
  }

}
