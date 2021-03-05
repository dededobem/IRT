import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Neighborhood } from '../../neighborhood/neighborhood.model';
import { NeighborhoodService } from '../../neighborhood/neighborhood.service';
import { RequestUpdateDrugstore } from '../drugstore.model';
import { DrugstoreService } from '../drugstore.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-drugstore',
  templateUrl: './update-drugstore.component.html',
  styleUrls: ['./update-drugstore.component.css']
})
export class UpdateDrugstoreComponent implements OnInit {
  request: RequestUpdateDrugstore = {    
    id: '',
    name: '',        
    roundTheClock: false,
    foundationDate: new Date,
    neighborhoodId: ''
  
  };
  
  neighborhoods: Neighborhood[] = [];

  updateDrugstore = new FormGroup({
    nameControl: new FormControl('', Validators.required),
    neighborhoodControl: new FormControl('', Validators.required)
  });

  constructor(private drugstoreService: DrugstoreService, 
    private neighborhoodService: NeighborhoodService,
    private route: ActivatedRoute, 
    private navigation: Router,
    private location: Location) { }

  ngOnInit() {    
    this.drugstoreService.getDrugstore(this.route.snapshot.paramMap.get('id')).subscribe(res => {
      this.request = {
        id: res.id,
        name: res.name,        
        roundTheClock: res.roundTheClock,
        foundationDate: res.foundationDate,
        neighborhoodId: res.neighborhood.id
      }
    }); 
    
    this.neighborhoodService.all().subscribe(res => {
      this.neighborhoods = res;
    })
  }

  update() {
    this.drugstoreService.update(this.route.snapshot.paramMap.get('id'), this.request).subscribe(res => {
      Swal.fire("", "Farmácia atualizada com sucesso!", "success").then(res => {
        this.navigation.navigate(['/drugstore/by-name']);
      }); 
    });
  }

  back(){
    this.location.back();
  }
}
