import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  //public forecasts: WeatherForecast[];

  public neighborhoods: Neighborhood[];

  url = 'https://localhost:44384/api/neighborhood';

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));
  //}
  constructor(http: HttpClient) {
    http.get<Neighborhood[]>(this.url).subscribe(result => {
      this.neighborhoods = result;
    }, error => console.error(error));
  }
}

//interface WeatherForecast {
//  date: string;
//  temperatureC: number;
//  temperatureF: number;
//  summary: string;
//}

interface Neighborhood {
  id: string;
  name: string;
}
