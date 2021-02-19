import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  constructor(private httpClient: HttpClient) {}

  path = 'https://localhost:44388/api/Cars/';

  getCars(): Observable<any> {
    return this.httpClient.get(this.path + 'getall');
  }
}
