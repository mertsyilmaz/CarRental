import { Component, OnInit } from '@angular/core';
import { Car } from '../models/car';
import { CarService } from '../services/car.service';

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
    this.carService.getCars().subscribe((data) => {
      this.cars = data["data"];
      console.log("Success : "+ data["success"] + " | Message : " + data["message"]);
    });
  }
}
