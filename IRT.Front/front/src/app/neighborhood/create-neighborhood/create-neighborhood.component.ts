import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MyErrorStateMatcher } from 'src/app/shared/error/myErrorStateMatcher';
import { RequestCreate, ResponseCreate } from '../neighborhood.model';
import { NeighborhoodService } from '../neighborhood.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-create-neighborhood',
  templateUrl: './create-neighborhood.component.html',
  styleUrls: ['./create-neighborhood.component.css']
})
export class CreateNeighborhoodComponent implements OnInit {

  request: RequestCreate = {
    name: ''
  }

  response: ResponseCreate = {
    id: '',
    name: ''
  };

  nameFormControl = new FormControl('', Validators.required);
  matcher = new MyErrorStateMatcher();

  constructor(private neighborhoodService: NeighborhoodService,
    private navigation: Router) { }

  ngOnInit() {
  }

  save(){
    this.neighborhoodService.createNeighBorhood(this.request).subscribe(res => {      
      Swal.fire("", "Bairro cadastrado com sucesso!", "success").then(res => {
        this.navigation.navigate(["/neighborhood"]);
      });      
    });
  }

  back(){
    this.navigation.navigate(["/neighborhood"]);
  }

}
