import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { MyErrorStateMatcher } from 'src/app/shared/error/myErrorStateMatcher';
import { RequestNeighborhood, Neighborhood } from '../neighborhood.model';
import { NeighborhoodService } from '../neighborhood.service';

@Component({
  selector: 'app-list-neighborhood',
  templateUrl: './list-neighborhood.component.html',
  styleUrls: ['./list-neighborhood.component.css']
})
export class ListNeighborhoodComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name'];

  requestNeighborhood: RequestNeighborhood = {
    name: '',
    maxResults: 0
  };
  responseNeighborhoods: Neighborhood[] = [];
  isLoading = false;
  
  constructor(private neighborhoodService: NeighborhoodService) {}

  ngOnInit() { 
  }

  search() {    
    this.isLoading = true;
    this.neighborhoodService.getNeighborhoods(this.requestNeighborhood).subscribe(res => {
      this.responseNeighborhoods = res;
      this.isLoading = false;
    });
  }

  maxResultsFormControl = new FormControl('', [
    Validators.required,
  ]);
  matcher = new MyErrorStateMatcher();
}

