import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Neighborhood } from 'src/app/neighborhood/neighborhood.model';
import { NeighborhoodService } from 'src/app/neighborhood/neighborhood.service';
import { RequestDrugstoreNeighborhood, ResponseDrugstoreNeighborhood } from '../drugstore.model';
import { DrugstoreService } from '../drugstore.service';

@Component({
  selector: 'app-list-drugstore-by-neighborhood',
  templateUrl: './list-drugstore-by-neighborhood.component.html',
  styleUrls: ['./list-drugstore-by-neighborhood.component.css']
})
export class ListDrugstoreByNeighborhoodComponent implements OnInit {

  displayedColumns: string[] = [
    'id', 
    'name', 
    'flgRoundTheClock',
    'foundationDate', 
    'update',
    'delete'
  ];
  
  neighborhoods: Neighborhood[] = [];
  responseDrugstores: ResponseDrugstoreNeighborhood[] = [];  
  requestDrugstoreNeighborhood: RequestDrugstoreNeighborhood = {
    neighborhoodId: '',
    roundTheClock: undefined
  }
  isLoading = false;

  neighborhoodList = new FormControl('', Validators.required);

  constructor(private neighborhoodService: NeighborhoodService,
    private drugstoreService: DrugstoreService) { }

  ngOnInit(): void {
    this.neighborhoodService.all().subscribe(res => {
      this.neighborhoods = res;
    });    
  }

  search() {
    this.isLoading = true;
    this.drugstoreService.getDrugstoreByNeighborhood(this.requestDrugstoreNeighborhood).then(res => {
      this.isLoading = false;
      this.responseDrugstores = res;
    });
  }

}
