import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { ResponseDrugstores } from '../drugstore.model';
import { DrugstoreService } from '../drugstore.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-delete-drugstore',
  templateUrl: './delete-drugstore.component.html',
  styleUrls: ['./delete-drugstore.component.css']
})
export class DeleteDrugstoreComponent implements OnInit {
  drugstore: ResponseDrugstores = {
    id: '',
    name: '',        
    roundTheClock: false,
    foundationDate: new Date,
    neighborhood: {
      id: '',
      name: ''
    },
    maxResults: 0    
  };

  constructor(private drugstoreService: DrugstoreService, 
    private route: ActivatedRoute,
    private navigation: Router,
    private location: Location ) { }

  ngOnInit() {
    this.drugstoreService.getDrugstore(this.route.snapshot.paramMap.get('id')).subscribe(res =>{      
      this.drugstore = res;
    });
  }

  delete(){
    this.drugstoreService.delete(this.route.snapshot.paramMap.get('id')).subscribe(res => {
      Swal.fire("", "Farmácia excluída com sucesso!", "success").then(res => {
        this.location.back();
      });      
    })
  }

  cancel(){
    this.location.back();
  }

}
