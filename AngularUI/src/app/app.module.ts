import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import{RouterModule} from '@angular/router';
import{appRoutes} from './routes';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { CarComponent } from './car/car.component';
import { from } from 'rxjs';
import { BrandComponent } from './brand/brand.component';
import { ColorComponent } from './color/color.component';
import { UserComponent } from './user/user.component';
import { RentalComponent } from './rental/rental.component';
import { CustomerComponent } from './customer/customer.component';
import { CarDetailComponent } from './car/car-detail/car-detail.component';
import { CarAddComponent } from './car/car-add/car-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AlertifyService } from './services/alertify.service';

@NgModule({
  declarations: [									
    AppComponent,
      NavComponent,
      CarComponent,
      BrandComponent,
      ColorComponent,
      UserComponent,
      RentalComponent,
      CustomerComponent,
      CarDetailComponent,
      CarAddComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AlertifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
