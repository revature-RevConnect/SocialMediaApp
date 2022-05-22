import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

import * as signalR from '@microsoft/signalr';

import { environment } from 'src/environments/environment';
import { ReceiveMessage } from '../Interfaces/receivemessage';
import { ChatUser } from '../Interfaces/UserSocial';


@Injectable({
  providedIn: 'root'
})
export class SignalRClientService {
  
  connection: signalR.HubConnection ;
  messenger = new Subject<ReceiveMessage>();
  onlineUsers = new Subject<ChatUser[]>();

  constructor() { 
    
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.chatURL}`+"?userName="+"dummy")
      .build();
   }
  sendMessage(receiver?: string, sender?: string, message?: string) {
    return this.connection.invoke("SendMessage", receiver, sender, message);
  }
  openConnection(name?: string) {
    
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.chatURL}`+"?userName="+name)
      .build();
    this.connection.start().then(res => {
      console.log("Connection started with return status: " + res);
    });
    this.chatMessageHandler();
  }
  chatMessageHandler() {
    this.connection.on("ReceiveMessage", (receiver, sender, message) => {
      this.messenger.next({
        receiver: receiver,
        sender: sender, 
        message: message,
        isSender: true
      });
    });
    this.connection.on("OnlineUsers", (user: ChatUser[]) => {
      this.onlineUsers.next(user);
    });
  }
}

