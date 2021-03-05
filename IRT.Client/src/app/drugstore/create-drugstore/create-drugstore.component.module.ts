import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CreateDrugstoreComponent } from './create-drugstore.component';
import { CreateDrugstoreRoutes } from './create-drugstore.routing';

@NgModule({
  imports: [
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(CreateDrugstoreRoutes)
  ],
  declarations: [CreateDrugstoreComponent]
})
export class DashboardModule {}