import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Brand } from '../models/brand';
import { Result } from '../models/result';

@Injectable({
  providedIn: 'root',
})
export class BrandService {
  constructor(private httpClient: HttpClient) {}
  path = 'https://localhost:44388/api/Brands/';

  getBrands(): Observable<Result<Brand[]>> {
    return this.httpClient.get<Result<Brand[]>>(this.path + 'getall');
  }
}
