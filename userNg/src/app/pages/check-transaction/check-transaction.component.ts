import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-check-transaction',
  templateUrl: './check-transaction.component.html',
  styleUrls: ['./check-transaction.component.scss']
})
export class CheckTransactionComponent implements OnInit {

  redirectUrl = 'http://localhost:4200/successTransaction';
  minSeconds = 3;
  maxSeconds = 10;
  
  getRandomTime = (min: number, max: number) => {
    return Math.floor(Math.random() * (max - min + 1) + min) * 1000;
  }

  ngOnInit(): void {
    setTimeout(() => {
      window.location.href = this.redirectUrl;
      console.log("ewkoijfewiufewj");
      
    }, this.getRandomTime(this.minSeconds, this.maxSeconds));
  }
  deadline = Date.now() + 1000 * 60 * 60 * 24 * 2 + 1000 * 30;
}
