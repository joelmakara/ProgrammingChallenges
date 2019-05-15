import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CalculateService {

  constructor(private http: HttpClient) { }

  calcUrl = 'https://localhost:44315/api/calc/';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8;', Accept: '*/*' })
  };

  evaluateExpression( expression: string) {
    let output = '';
    this.http.post(this.calcUrl, {}).subscribe(response => {
      output = response.toString();
      console.log(response);
    });
    return output;
  }
}
