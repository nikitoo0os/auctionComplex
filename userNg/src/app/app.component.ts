import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  token: any;
  ngOnInit(): void {
    this.refreshData();
  }
  public refreshData():void {
    this.token = localStorage.getItem('token');
  }

  logout(){
    localStorage.clear();
    window.location.reload();
    this.refreshData();
  }

  isCollapsed = false;
}
