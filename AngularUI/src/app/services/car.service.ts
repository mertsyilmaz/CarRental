import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car';
import { CarDetail } from '../models/carDetail';
import { Result } from '../models/result';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  constructor(private httpClient: HttpClient) {}

  path = 'https://localhost:44388/api/Cars/';

  getCars(): Observable<Result<Car[]>> {
    return this.httpClient.get<Result<Car[]>>(this.path + 'getall');
  }

  getCarById(carId: number): Observable<Result<Car>> {
    return this.httpClient.get<Result<Car>>(this.path + 'getbyid?id=' + carId);
  }

  add(car: Car) : Observable<Result<Car>> {
    return this.httpClient.post<Result<Car>>(this.path + 'add', car);
  }
}
