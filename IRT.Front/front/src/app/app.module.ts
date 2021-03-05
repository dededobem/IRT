import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListNeighborhoodComponent } from './neighborhood/list-neighborhood/list-neighborhood.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { NavigationComponent } from './layout/navigation/navigation.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule  } from '@angular/material/input';
import { MatTabsModule  } from '@angular/material/tabs';
import { MatCheckboxModule  } from '@angular/material/checkbox';
import { 
  ErrorStateMatcher, 
  MatNativeDateModule, 
  MAT_DATE_LOCALE, 
  ShowOnDirtyErrorStateMatcher 
} from '@angular/material/core';
import { ListDrugstoreComponent } from './drugstore/list-drugstore-by-name/list-drugstore.component';
import { CreateNeighborhoodComponent } from './neighborhood/create-neighborhood/create-neighborhood.component';
import { CreateDrugstoreComponent } from './drugstore/create-drugstore/create-drugstore.component';
import { UpdateDrugstoreComponent } from './drugstore/update-drugstore/update-drugstore.component';
import { DeleteDrugstoreComponent } from './drugstore/delete-drugstore/delete-drugstore.component';
import { MenuListItemComponent } from './layout/menu/menu-list-item.component';
import { MatSelectModule } from '@angular/material/select';
import { ListDrugstoreByNeighborhoodComponent } from './drugstore/list-drugstore-by-neighborhood/list-drugstore-by-neighborhood.component';
import { MatRadioModule } from '@angular/material/radio';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ChartsModule } from 'ng2-charts';
import { LoginComponent } from './auth/login/login.component';
import { authInterceptorProviders } from './helpers/auth.interceptor';
import { GraphicsComponent } from './graphics/bar/graphics.component';
import { PizzaGraphicComponent } from './graphics/pizza/pizza-graphic.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { GraphicsTotalComponent } from './graphics/bar-total/graphics-total.component';

@NgModule({
  declarations: [
    AppComponent,
    ListNeighborhoodComponent,
    CreateNeighborhoodComponent,    
    ListDrugstoreComponent,
    CreateDrugstoreComponent,
    UpdateDrugstoreComponent,
    DeleteDrugstoreComponent,
    DashboardComponent,
    NavigationComponent,
    MenuListItemComponent,
    ListDrugstoreByNeighborhoodComponent,
    GraphicsComponent,
    LoginComponent,
    PizzaGraphicComponent,
    GraphicsTotalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,   
    MatFormFieldModule,
    MatIconModule, 
    LayoutModule, 
    MatButtonModule, 
    MatSidenavModule, 
    MatListModule, 
    MatGridListModule, 
    MatCardModule, 
    MatMenuModule, 
    MatTableModule, 
    MatPaginatorModule, 
    MatSortModule,
    MatInputModule,
    MatTabsModule,
    MatCheckboxModule,
    MatSelectModule,
    MatRadioModule,
    MatDatepickerModule,
    MatNativeDateModule,
    ChartsModule,
    MatProgressSpinnerModule    
  ],
  providers: [
    authInterceptorProviders,
    {provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher},
    {provide: MAT_DATE_LOCALE, useValue: 'pt-BR'},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
