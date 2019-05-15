import { ApiResult } from './../models/ApiResult';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalculateService {

  constructor(private http: HttpClient) { }

  calcUrl = 'https://localhost:44315/api/calc/';

  evaluateExpression(expression) {
    return this.http.post<ApiResult>(this.calcUrl, expression);
  }
}
