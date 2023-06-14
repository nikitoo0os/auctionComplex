import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import axios, { AxiosResponse } from 'axios';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = 'http://localhost:8080';
  public userData$: any;
  constructor(private http: HttpClient) {}

  getData(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/users`);
  }
  register(formData: any) {
    const url = `${this.baseUrl}/user/register`;
    this.userData$ = axios.post(url, formData);
    return this.userData$
  }
  getUserByToken(token: any): any {
    const url = `${this.baseUrl}/user/login`;

    return new Promise((resolve, reject) => {     
      axios
        .post(url, {'token': token})
        .then((res) => {
          console.log(res);
          this.userData$ = res.data;
          resolve(res.data);
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });

  }

  login(formData: any) {
    const url = `${this.baseUrl}/user/login`;
    this.userData$ = axios.post(url, formData);
    return this.userData$
  }

  confirmLogin(formData: any) {
    const url = `${this.baseUrl}/user/login/confirm`;
    this.userData$ = axios.post(url, formData);
    return this.userData$
  }
  getUserById(id: number) {
    const url = `${this.baseUrl}/user/${id}`;

    return new Promise((resolve, reject) => {     
      axios
        .get(`${this.baseUrl}/user/${id}`)
        .then((res) => {
          console.log(res);
          this.userData$ = res.data;
          resolve(res.data);
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });
  }

  
}
