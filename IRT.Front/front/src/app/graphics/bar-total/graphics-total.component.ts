import { Component, OnInit } from '@angular/core';
import { ChartType } from 'chart.js';
import { Label, MultiDataSet } from 'ng2-charts';
import { DrugstoreService } from 'src/app/drugstore/drugstore.service';
import { NeighborhoodService } from 'src/app/neighborhood/neighborhood.service';

@Component({
  selector: 'app-graphics-total',
  templateUrl: './graphics-total.component.html',
  styleUrls: ['./graphics-total.component.css']
})
export class GraphicsTotalComponent implements OnInit{

  total: number[] = [];

  constructor(private neighborhoodService: NeighborhoodService,
    private drugstoreService: DrugstoreService) {
  }

  ngOnInit() {
    this.neighborhoodService.all().subscribe(async res => {
      this.total.push(res.length);
    });
    this.drugstoreService.all().subscribe(res => {
      this.total.push(res.length);
    });
  }    

  public doughnutChartType: ChartType = 'doughnut';
  public doughnutChartLabels: Label[] = ['Bairros', 'Farmácias'];
  public doughnutChartColors = [
    {
      backgroundColor: [
        'rgba(110, 114, 20, 1)',
        'rgba(118, 183, 172, 1)'       
    ]
    }
  ];  
  public doughnutChartData: MultiDataSet = [
    this.total,    
  ];

  // events
  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  } 

}
