import { Component, OnInit } from '@angular/core';
import { RequestDrugstore, ResponseDrugstores } from '../drugstore.model';
import { DrugstoreService } from '../drugstore.service';

@Component({
  selector: 'app-list-drugstore',
  templateUrl: './list-drugstore.component.html',
  styleUrls: ['./list-drugstore.component.css']
})
export class ListDrugstoreComponent implements OnInit {
  
  requestDrugstore: RequestDrugstore = {
    name: '',
    maxResults: 0
  };
  responseDrugstores: ResponseDrugstores[];

  constructor(private drugstoreService: DrugstoreService) {}
  
  ngOnInit() {
  }

  search() {
    this.drugstoreService.getDrugstores(this.requestDrugstore).subscribe(res => {
        this.responseDrugstores = res;
        console.log(res);
      }
    );
  }

}

