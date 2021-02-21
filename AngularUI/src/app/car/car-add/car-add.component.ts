import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { Car } from 'src/app/models/car';
import { AlertifyService } from 'src/app/services/alertify.service';
import { BrandService } from 'src/app/services/brand.service';
import { ColorService } from 'src/app/services/color.service';
import { Brand } from 'src/app/models/brand';
import { Color } from 'src/app/models/color';

@Component({
  selector: 'app-car-add',
  templateUrl: './car-add.component.html',
  styleUrls: ['./car-add.component.css'],
  providers: [CarService],
})
export class CarAddComponent implements OnInit {
  constructor(
    private carService: CarService,
    private formBuilder: FormBuilder,
    private alertifyService: AlertifyService,
    private brandService: BrandService,
    private colorService: ColorService
  ) {}

  brands: Brand[];
  colors: Color[];
  car: Car;
  carAddForm: FormGroup;

  ngOnInit() {
    this.brandService.getBrands().subscribe((result) => {
      this.brands = result.data;
    });
    this.colorService.getColors().subscribe((result) => {
      this.colors = result.data;
    });
    this.createCarForm();
  }

  get f(){return this.carAddForm.controls}

  add() {
    if (this.carAddForm.valid) {
      this.car = Object.assign({}, this.carAddForm.value);
      this.carService.add(this.car).subscribe((result) => {
        if (result.success) {
          this.alertifyService.success(result.message);
        } else {
          this.alertifyService.error(result.message);
        }
      });
    }
  }

  createCarForm() {
    this.carAddForm = this.formBuilder.group({
      name: ["",[Validators.required,Validators.minLength(2)]],
      brandId: ["",Validators.required],
      colorId: ["",Validators.required],
      modelYear: ["",Validators.required],
      dailyPrice: ["",Validators.required],
      description: ["",Validators.required],
    });
  }
}
