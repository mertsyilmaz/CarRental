import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Color } from '../models/color';
import { Result } from '../models/result';

@Injectable({
  providedIn: 'root',
})
export class ColorService {
  constructor(private httpClient: HttpClient) {}
  path = 'https://localhost:44388/api/Colors/';

  getColors(): Observable<Result<Color[]>> {
    return this.httpClient.get<Result<Color[]>>(this.path + 'getall');
  }
}
