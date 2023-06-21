import { Injectable } from '@angular/core';
import { IMessage, Stomp } from '@stomp/stompjs';
import { Observable } from 'rxjs';
import * as SockJS from 'sockjs-client';

@Injectable({
  providedIn: 'root'
})
export class WebsocketService {
  private stompClient;

  constructor() { 
    const socket = new SockJS('http://localhost:8080/ws');
    this.stompClient = Stomp.over(socket);  
    this.stompClient.activate();
  }

  connectChat(id: string): Observable<any>{
    return new Observable(observer => {
      this.stompClient.connect({}, () => {
        this.stompClient.subscribe(`/topic/chat/${id}`, (message: IMessage) => {
          observer.next(JSON.parse(message.body));
      });
    })
  })}

  sendMessage(idChat: string, text:string, userId: number){
      this.stompClient.send("/app/hello", {}, JSON.stringify({'userId': userId, 'text': text, 'auctionChatId': idChat}));
  }

}
