import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { MyErrorStateMatcher } from 'src/app/shared/error/myErrorStateMatcher';
import { RequestDrugstore, ResponseDrugstores } from '../drugstore.model';
import { DrugstoreService } from '../drugstore.service';

@Component({
  selector: 'app-list-drugstore',
  templateUrl: './list-drugstore.component.html',
  styleUrls: ['./list-drugstore.component.css']
})
export class ListDrugstoreComponent implements OnInit {

  displayedColumns: string[] = [
    'id', 
    'name', 
    'flgRoundTheClock', 
    'foundationDate', 
    'neighborhood',
    'update',
    'delete'
  ];
  
  requestDrugstore: RequestDrugstore = {
    name: '',
    maxResults: 0
  };
  responseDrugstores: ResponseDrugstores[] = [];
  isLoading = false;

  constructor(private drugstoreService: DrugstoreService) {}
  
  ngOnInit() {    
  }

  search() {
    this.isLoading = true;
    this.drugstoreService.getDrugstores(this.requestDrugstore).subscribe(res => {
      this.isLoading = false;
      this.responseDrugstores = res;
    });
  }

  maxResultsFormControl = new FormControl('', [
    Validators.required,
  ]);
  matcher = new MyErrorStateMatcher();

}

