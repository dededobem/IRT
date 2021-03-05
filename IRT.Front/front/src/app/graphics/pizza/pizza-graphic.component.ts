import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { NeighborhoodService } from 'src/app/neighborhood/neighborhood.service';

@Component({
  selector: 'app-pizza-graphic',
  templateUrl: './pizza-graphic.component.html',
  styleUrls: ['./pizza-graphic.component.css']
})
export class PizzaGraphicComponent implements OnInit {

  neighborhoods: string[] = [];
  countDrugstores: number[] = [];
  colorPizza: string[] = []

  public pieChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: 'top',
    },
    plugins: {
      datalabels: {
        formatter: (ctx: any) => {
          const label = ctx.chart.data.labels[ctx.dataIndex];
          return label;
        },
      },
    }
  };
  public pieChartLabels: Label[] = this.neighborhoods;
  public pieChartData: number[] = this.countDrugstores;
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartColors = [
    {
      backgroundColor: this.colorPizza,
    },
  ];

  constructor(private neighborhoodService: NeighborhoodService) { }

  ngOnInit(): void {
    this.neighborhoodService.all().subscribe(res => {
      res.map(neighborhood => {
        if (neighborhood.countDrugstore && neighborhood.countDrugstore > 0) {
          this.neighborhoods.push(neighborhood.name);
          this.countDrugstores.push(neighborhood.countDrugstore);
          this.colorPizza.push('#'+(Math.random().toString(16)+"000000").substring(2,8));          
        }
      });     
    });
  }

  // events
  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }  

}
