import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { RequestDrugstoreNeighborhood } from 'src/app/drugstore/drugstore.model';
import { DrugstoreService } from 'src/app/drugstore/drugstore.service';
import { NeighborhoodService } from 'src/app/neighborhood/neighborhood.service';

@Component({
  selector: 'app-graphics',
  templateUrl: './graphics.component.html',
  styleUrls: ['./graphics.component.css']
})
export class GraphicsComponent implements OnInit{
   
  request: RequestDrugstoreNeighborhood = {
    neighborhoodId: '',
    roundTheClock: undefined
  };

  neighborhoods: string[] = [];
  drugstores24hrs: number[] = [];
  drugstoresNo24hrs: number[] = [];

  valueNumberDrugstore = 0;

  constructor(private neighborhoodService: NeighborhoodService,
    private drugstoreService: DrugstoreService) {
  }

  ngOnInit() {
    this.neighborhoodService.all().subscribe(async res => {
      for (let neighborhood of res) {
        if (neighborhood.countDrugstore && neighborhood.countDrugstore > 0) {
          this.neighborhoods.push(neighborhood.name);
          await this.getDrugstoreByNeighborhoodBool(neighborhood.id, true).then(res => {
            this.drugstores24hrs.push(res);
          });
          await this.getDrugstoreByNeighborhoodBool(neighborhood.id, false).then(res => {
            this.drugstoresNo24hrs.push(res);
          });
        }
      }
    });
  } 

  async getDrugstoreByNeighborhoodBool(idNeighborhood: string, roundTheClock: boolean): Promise<number> {    
    await this.drugstoreService.getDrugstoreByNeighborhoodGraphic(idNeighborhood, roundTheClock).then(data => {
      this.valueNumberDrugstore = data.length;      
    });  
    return this.valueNumberDrugstore;  
  }

  public barChartOptions: ChartOptions = {
    responsive: true,
    scales: { xAxes: [{}], yAxes: [{}] },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };
  public barChartLabels: Label[] = this.neighborhoods;
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartColors: Color[] = [
    { backgroundColor: '#679fcd' },
    { backgroundColor: '#f44336de' },
  ]

  public barChartData: ChartDataSets[] = [
    { 
      data: this.drugstores24hrs, 
      label: 'Funciona 24Hrs',
      stack: 'st' 
    },
    { 
      data: this.drugstoresNo24hrs, 
      label: 'Não Funciona 24Hrs',
      stack: 'st' 
    }
  ];

  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }
  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }  

}
