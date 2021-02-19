import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-drugstore',
  templateUrl: './drugstore.component.html',
  styleUrls: ['./drugstore.component.css']
})
export class DrugstoreComponent implements OnInit {

  public drugstores: Drugstore[];

  url = 'https://localhost:44384/api/drugstore';
  
  constructor(http: HttpClient) {
    http.get<Drugstore[]>(this.url).subscribe(result => {
      this.drugstores = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface Drugstore {
  id: string;
  name: string;
  flgRoundTheClock: boolean;
  foundationDate: Date;  
}
