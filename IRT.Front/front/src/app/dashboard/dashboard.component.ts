import { Component } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  
  cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return [
          { col1: 2, row1: 1 },
          { col2: 2, row2: 1 },
          { col3: 2, row3: 1 }
        ];
      }

      return [
        { col1: 2, row1: 2 },
        { col2: 1, row2: 1 },
        { col3: 1, row3: 1 }
      ];
    })
  );

  constructor(private breakpointObserver: BreakpointObserver) {}
}
