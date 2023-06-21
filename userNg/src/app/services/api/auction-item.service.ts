import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class AuctionItemService {


  private baseUrl = 'http://localhost:8080';
  public auctionItemsData$: any;
  public auctionItemData$: any;
  constructor(private http: HttpClient) {}

  getData(): Promise<any> {
    return new Promise((resolve, reject) => {
      axios
        .get(`${this.baseUrl}/auctionItem/`)
        .then((res) => {
          console.log(res);
          resolve(res.data);
          this.auctionItemData$ = res.data;
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });
  }

  getAuctionItemById(auctionItemId: number): Promise<any>{
    return new Promise((resolve, reject) => {
      axios
        .get(`${this.baseUrl}/auctionItem/${auctionItemId}`)
        .then((res) => {
          console.log(res);
          resolve(res.data);
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });
  }

  getAuctionItemsByAuctioneer(id: number): Promise<any>{

    return new Promise((resolve, reject) => {
      axios
        .post(`${this.baseUrl}/auctionItem/auctioneer`, {'id': id})
        .then((res) => {
          console.log(res);
          resolve(res.data);
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });
  }

  getAllCategories() {
    return new Promise((resolve, reject) => {
      axios
        .post(`${this.baseUrl}/auctionItem/categories`)
        .then((res) => {
          console.log(res);
          resolve(res.data);
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });
  }

  getFilterAuctionItem(filter: { investmentVolume: any; time: any; category: any; }) {
    return new Promise((resolve, reject) => {
      axios
        .post(`${this.baseUrl}/auctionItem/filter`, filter)
        .then((res) => {
          console.log(res);
          resolve(res.data);
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });
  }


}
