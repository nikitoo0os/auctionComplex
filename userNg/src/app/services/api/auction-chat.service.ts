import { Injectable } from '@angular/core';
import axios from 'axios';

interface AuctionChatData{
  id: number,
  auctionItemId: number
}
interface chatMessageData{
  id: number,
  text: string, 
  auctionChatId: string,
  userId: number,
  attachmentId: number,
  timestamp: string
}

@Injectable({
  providedIn: 'root'
})
export class AuctionChatService {
  private baseUrl = 'http://localhost:8080';
  constructor() { }

  getAuctionChatByAuctionId(auctionId: number): Promise<any>{
    return new Promise((resolve, reject) => {     
      axios
        .get(`${this.baseUrl}/auctionChat/get/${auctionId}`)
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
chatMessages: chatMessageData[] = [];

  getChatMessagesByAuctionId(auctionId: number): Promise<any>{
    return new Promise((resolve, reject) => {     
      axios
        .get(`${this.baseUrl}/auctionChat/${auctionId}`)
        .then((res) => {
          console.log(res);
          this.chatMessages = res.data;
          resolve(res.data);
        })
        .catch((err) => {
          console.log(err);
          reject(err);
        });
    });
  }
}
