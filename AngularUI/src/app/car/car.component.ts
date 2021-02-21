import { Component, OnInit } from '@angular/core';
import {CarDetail} from '../models/carDetail';
import { CarService } from '../services/car.service';
import { from } from 'rxjs';
import { Car } from '../models/car';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.scss'],
  providers: [CarService],
})
export class CarComponent implements OnInit {
  constructor(private carService: CarService) {}
  cars: Car[];
  ngOnInit() {
    this.carService.getCars().subscribe((result) => {
      console.log(result.data);
      this.cars = result.data;
      console.log("Success : "+ result.success + " | Message : " + result.message);
    });
  }
}
