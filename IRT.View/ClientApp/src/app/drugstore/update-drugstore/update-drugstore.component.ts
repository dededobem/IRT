import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResponseNeighborhoods } from 'src/app/neighborhood/neighborhood.model';
import { NeighborhoodService } from 'src/app/neighborhood/neighborhood.service';
import { RequestUpdateDrugstore } from '../drugstore.model';
import { DrugstoreService } from '../drugstore.service';

@Component({
  selector: 'app-update-drugstore',
  templateUrl: './update-drugstore.component.html',
  styleUrls: ['./update-drugstore.component.css']
})
export class UpdateDrugstoreComponent implements OnInit {

  id: string;
  request: RequestUpdateDrugstore;
  neighborhoods: ResponseNeighborhoods;

  constructor(private drugstoreService: DrugstoreService, 
    private neighborhoodService: NeighborhoodService,
    private route: ActivatedRoute, 
    private navigation: Router) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.drugstoreService.getDrugstore(this.id).subscribe(res => {
      this.request = {
        id: res.id,
        name: res.name,        
        roundTheClock: res.roundTheClock,
        foundationDate: res.foundationDate,
        neighborhoodId: res.neighborhoodId
      }
    }); 
    
    this.neighborhoodService.all().subscribe(res => {
      this.neighborhoods = res;
    })
  }

  update() {
    this.drugstoreService.update(this.id, this.request).subscribe(res => {
      alert("Farmácia atualizada!");
      this.navigation.navigate(['/drugstore']);
    });
  }

  back(){
    this.navigation.navigate(['/drugstore']);
  }
}
