import {Routes} from '@angular/router';
import { CarComponent } from './car/car.component';
import { from } from 'rxjs';
import { ColorComponent } from './color/color.component';
import { BrandComponent } from './brand/brand.component';
import { CustomerComponent } from './customer/customer.component';
import { RentalComponent } from './rental/rental.component';
import { UserComponent } from './user/user.component';
import { CarDetailComponent } from './car/car-detail/car-detail.component';
import { CarAddComponent } from './car/car-add/car-add.component';

export const appRoutes : Routes = [
  {
    path: 'car',
    component: CarComponent,
  },
  {
    path: 'carDetail/:carId',
    component: CarDetailComponent,
  },
  {
    path: 'carAdd',
    component: CarAddComponent,
  },
  {
    path: 'color',
    component: ColorComponent,
  },
  {
    path: 'brand',
    component: BrandComponent,
  },
  {
    path: 'customer',
    component: CustomerComponent,
  },
  {
    path: 'rental',
    component: RentalComponent,
  },
  {
    path: 'user',
    component: UserComponent,
  },
  {
    path: '**',
    redirectTo: 'car',
    pathMatch: 'full',
  },
];
