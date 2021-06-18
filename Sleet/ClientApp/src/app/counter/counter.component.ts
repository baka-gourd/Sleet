import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public incrementCounter() {
    if (this.currentCount === 0) {
      this.currentCount++;
      return;
    }
    this.currentCount = this.currentCount + this.currentCount;
  }
}
