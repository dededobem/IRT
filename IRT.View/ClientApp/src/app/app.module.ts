import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CreateNeighborhoodComponent } from './neighborhood/create-neighborhood/create-neighborhood.component';
import { UpdateDrugstoreComponent } from './drugstore/update-drugstore/update-drugstore.component';
import { CreateDrugstoreComponent } from './drugstore/create-drugstore/create-drugstore.component';
import { DeleteDrugstoreComponent } from './drugstore/delete-drugstore/delete-drugstore.component';
import { ListNeighborhoodComponent } from './neighborhood/list-neighborhood/list-neighborhood.component';
import { ListDrugstoreComponent } from './drugstore/list-drugstore/list-drugstore.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ListNeighborhoodComponent,
    CreateNeighborhoodComponent,
    ListDrugstoreComponent,
    CreateDrugstoreComponent,
    UpdateDrugstoreComponent,
    DeleteDrugstoreComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'neighborhood', component: ListNeighborhoodComponent },
      { path: 'neighborhood/create', component: CreateNeighborhoodComponent },
      { path: 'drugstore', component: ListDrugstoreComponent },
      { path: 'drugstore/create', component: CreateDrugstoreComponent },
      { path: 'drugstore/update/:id', component: UpdateDrugstoreComponent },
      { path: 'drugstore/delete/:id', component: DeleteDrugstoreComponent },      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
