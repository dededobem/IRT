import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ResponseNeighborhoods } from '../../neighborhood/neighborhood.model';
import { NeighborhoodService } from '../../neighborhood/neighborhood.service';
import { RequestCreateDrugstore, ResponseCreateDrugstore } from '../drugstore.model';
import { DrugstoreService } from '../drugstore.service';

@Component({
  selector: 'app-create-drugstore',
  templateUrl: './create-drugstore.component.html',
  styleUrls: ['./create-drugstore.component.css']
})
export class CreateDrugstoreComponent implements OnInit {

  request: RequestCreateDrugstore = {
    name: '',
    roundTheClock: false,
    foundationDate: new Date(),
    neighborhoodId: ''
  }

  response: ResponseCreateDrugstore;

  neighborhoods: ResponseNeighborhoods;

  constructor(private drugstorService: DrugstoreService, 
    private neighborhoodService: NeighborhoodService,
    private navigation: Router) { }

  ngOnInit() {
    this.neighborhoodService.all().subscribe(res => {
      this.neighborhoods = res;
    })
  }

  save(){
    this.drugstorService.createDrugstore(this.request).subscribe(res => {
      this.response = res; 
      alert("Farmácia criada com sucesso!");
      this.navigation.navigate(['/drugstore']);           
    });
  }

}
