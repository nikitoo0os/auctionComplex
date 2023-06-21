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

  getWalletByUserId(userId: number): Promise<any> {
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

  createConfirmCode(){
    const token = localStorage.getItem('token');
    return new Promise((resolve, reject) => {
      axios
        .post(`${this.baseUrl}/wallet/user/new/code`, token)
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

  createWalletByAddressAndUserId(formData: any){
    console.log(formData);
    return new Promise((resolve, reject) => {
      axios
        .post(`${this.baseUrl}/wallet/user/new`, formData)
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

  dropWalletByIdWallet(data: any){
    console.log(data);
    return new Promise((resolve, reject) => {
      axios
        .post(`${this.baseUrl}/wallet/user/drop`, data)
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
