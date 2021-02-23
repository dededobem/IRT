import { Component, OnInit } from '@angular/core';
import { RequestCreate, ResponseCreate } from '../neighborhood.model';
import { NeighborhoodService } from '../neighborhood.service';

@Component({
  selector: 'app-create-neighborhood',
  templateUrl: './create-neighborhood.component.html',
  styleUrls: ['./create-neighborhood.component.css']
})
export class CreateNeighborhoodComponent implements OnInit {

  request: RequestCreate = {
    name: ''
  }

  response: ResponseCreate

  constructor(private neighborhoodService: NeighborhoodService) { }

  ngOnInit() {
  }

  save(){
    this.neighborhoodService.createNeighBorhood(this.request).subscribe(res => {
      this.response = res;
    });
  }

}
