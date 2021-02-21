import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css'],
  providers: [CarService],
})
export class CarDetailComponent implements OnInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    private carService: CarService
  ) {}
  car: Car;
  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.getCarById(params['carId']);
    });
  }

  getCarById(carId: number) {
    this.carService.getCarById(carId).subscribe((result) => {
    this.car = result.data;
    });
  }
}
