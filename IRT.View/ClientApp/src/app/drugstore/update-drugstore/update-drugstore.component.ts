import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DrugstoreService } from '../drugstore.service';

@Component({
  selector: 'app-update-drugstore',
  templateUrl: './update-drugstore.component.html',
  styleUrls: ['./update-drugstore.component.css']
})
export class UpdateDrugstoreComponent implements OnInit {

  id: string;
  /* request: RequestUpdate; */

  constructor(private drugstoreService: DrugstoreService, private route: ActivatedRoute) { }

  ngOnInit() {
    /* this.id = this.route.snapshot.paramMap.get('id');
    this.drugstoreService.getDrugstore(this.id).subscribe(res =>{
      this.request = {
        name: res.data.name
      }
    }); */

    /* update(){
      this.drugstoreService.updateDrugstore(this.id, this.request).subscribe(res => {
        alert("Drugstore updated!");
      });
    } */
  }

}
