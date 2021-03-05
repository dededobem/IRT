import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResponseUpdateDrugstore } from '../drugstore.model';
import { DrugstoreService } from '../drugstore.service';

@Component({
  selector: 'app-delete-drugstore',
  templateUrl: './delete-drugstore.component.html',
  styleUrls: ['./delete-drugstore.component.css']
})
export class DeleteDrugstoreComponent implements OnInit {

  id: string;
  drugstore: ResponseUpdateDrugstore;

  constructor(private drugstoreService: DrugstoreService, 
    private route: ActivatedRoute,
    private navigation: Router ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.drugstoreService.getDrugstore(this.id).subscribe(res =>{
      this.drugstore = res;
    });
  }

  delete(){
    this.drugstoreService.delete(this.id).subscribe(res => {
      alert("Removido com sucesso")
      this.navigation.navigate(['/drugstore']);
    })
  }

  cancel(){
    this.navigation.navigate(['/drugstore']);
  }

}
