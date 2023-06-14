import { Injectable, ɵsetAllowDuplicateNgModuleIdsForTest } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import axios, { AxiosResponse } from 'axios';

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
}
