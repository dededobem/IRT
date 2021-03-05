import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CreateDrugstoreComponent } from './drugstore/create-drugstore/create-drugstore.component';
import { DeleteDrugstoreComponent } from './drugstore/delete-drugstore/delete-drugstore.component';
import { ListDrugstoreComponent } from './drugstore/list-drugstore-by-name/list-drugstore.component';
import { ListDrugstoreByNeighborhoodComponent } from './drugstore/list-drugstore-by-neighborhood/list-drugstore-by-neighborhood.component';
import { UpdateDrugstoreComponent } from './drugstore/update-drugstore/update-drugstore.component';
import { CreateNeighborhoodComponent } from './neighborhood/create-neighborhood/create-neighborhood.component';
import { ListNeighborhoodComponent } from './neighborhood/list-neighborhood/list-neighborhood.component';

const routes: Routes = [  
  { path: '', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent },  
  { path: 'neighborhood', component: ListNeighborhoodComponent },
  { path: 'neighborhood/add', component: CreateNeighborhoodComponent },
  { path: 'drugstore/by-name', component: ListDrugstoreComponent },
  { path: 'drugstore/by-neighborhood', component: ListDrugstoreByNeighborhoodComponent },
  { path: 'drugstore/add', component: CreateDrugstoreComponent },
  { path: 'drugstore/update/:id', component: UpdateDrugstoreComponent },
  { path: 'drugstore/delete/:id', component: DeleteDrugstoreComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
