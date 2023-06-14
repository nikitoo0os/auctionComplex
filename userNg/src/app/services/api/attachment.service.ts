import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root'
})
export class AttachmentService {
  private baseUrl = 'http://localhost:8080';

  constructor(private http: HttpClient) {}

  getAttachmentsByAuctionItemId(auctionItemId: number): Promise<any>{
    return new Promise((resolve, reject) => {
      axios
        .get(`${this.baseUrl}/auctionItem/attachments/${auctionItemId}`)
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
  getAttachmentsById(attachmentId: number): Promise<any>{
    return new Promise((resolve, reject) => {
      axios
        .get(`${this.baseUrl}/attachments/${attachmentId}`)
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



