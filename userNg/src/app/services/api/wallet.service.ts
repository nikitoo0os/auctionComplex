import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import axios, { AxiosResponse } from 'axios';

@Injectable({
  providedIn: 'root',
})
export class WalletService {
  private baseUrl = 'http://localhost:8080';
  public userData$: any;
  constructor() {}

  getWalletByUserId(userId: number): Promise<any>{
    return new Promise((resolve, reject) => {     
      axios
        .get(`${this.baseUrl}/wallet/user/${userId}`)
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