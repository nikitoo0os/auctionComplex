import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root'
})
export class BidService {
  private baseUrl = 'http://localhost:8080';
  constructor() { }

  getBidsByAuctionItemId(auctionId: number): Promise<any>{
    return new Promise((resolve, reject) => {     
      axios
        .get(`${this.baseUrl}/auctionChat/get/bids/${auctionId}`)
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

  getBestBidByAuctionItemId(id: number): Promise<any> {
    return new Promise((resolve, reject) => {     
      axios
        .post(`${this.baseUrl}/bid/best`, {'id': id})
        .then((res) => {
          resolve(res.data);
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });
  }
}
