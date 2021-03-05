import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Neighborhood } from '../../neighborhood/neighborhood.model';
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

  response: ResponseCreateDrugstore = {
    id: '',
    name: '',
    roundTheClock: false,
    foundationDate: new Date(),
    neighborhoodId: ''
  };

  neighborhoods: Neighborhood[] = [];

  addDrugstore = new FormGroup({
    nameControl: new FormControl('', Validators.required),
    neighborhoodControl: new FormControl('', Validators.required)
  });

  constructor(private drugstorService: DrugstoreService, 
    private neighborhoodService: NeighborhoodService,
    private navigation: Router) { }
    

  ngOnInit() {
    this.neighborhoodService.all().subscribe(res => {
      this.neighborhoods = res;
    });
  }

  save(){
    this.drugstorService.createDrugstore(this.request).subscribe(res => {      
      Swal.fire("", "Farmácia cadastrada com sucesso!", "success").then(res => {
        this.navigation.navigate(['/drugstore/by-name']);
      });                 
    });
  }

  back(){
    this.navigation.navigate(["/drugstore/by-name"]);
  }

}
