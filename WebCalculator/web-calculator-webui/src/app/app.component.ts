import { ApiResult } from './models/ApiResult';
import { CalculateService } from './services/calculate.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Joel\'s Web Calculator';

  constructor(private calculateService: CalculateService) { }

  result: string;
  serverResponse: ApiResult;

  async submitExpression( expression: string) {
    const inupt = {Expression: expression };
    this.serverResponse = await this.calculateService.evaluateExpression(inupt).toPromise();
    this.result = this.serverResponse.result;
  }
}
