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

  expression: string;
  result: string;

  submitExpression() {
      this.result = this.calculateService.evaluateExpression(this.expression);
  }
}
