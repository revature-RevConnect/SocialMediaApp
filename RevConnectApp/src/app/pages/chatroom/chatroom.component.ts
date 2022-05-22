import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService, User } from '@auth0/auth0-angular';
import { Subscription } from 'rxjs';
import { SignalRClientService } from 'src/app/services/signal-rclient.service';
import { ReceiveMessage } from 'src/app/Interfaces/receivemessage';
import { ChatUser } from 'src/app/Interfaces/UserSocial';

@Component({
  selector: 'app-chatroom',
  templateUrl: './chatroom.component.html',
  styleUrls: ['./chatroom.component.css']
})
export class ChatroomComponent implements OnInit, OnDestroy {
  message: string = '';
  userSender: ChatUser = { };
  defaultReceiver: ChatUser = { name: 'Everyone' };
  userReceiver: ChatUser = this.defaultReceiver;
  //loggedInUser?: User;
  userName: string = 'peter';
  chatContainer: ReceiveMessage[] = [];
  onlineUsers: ChatUser[] = [];
  subscription: Subscription;

  constructor(    public auth: AuthService,
    private signalrClientService: SignalRClientService)
  {
    this.auth.getUser().subscribe( u => { this.userSender.name = u?.nickname; } );
    console.log("logging 1: this.userSender.name = "+this.userSender.name);
    this.subscription = new Subscription();
    this.subscription.add(this.signalrClientService.messenger.subscribe((res: ReceiveMessage) => {
      this.chatContainer.push(res);
    }));
    this.subscription.add(this.signalrClientService.onlineUsers.subscribe((res: ChatUser[]) => {
      this.onlineUsers = res;
    }));
  }

  ngOnInit(): void {
    this.auth.getUser<User>().subscribe( u => {
      this.connectHub(u?.nickname);
    });
    
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
  
  connectHub(name?: string) {
    
    this.signalrClientService.openConnection(name);
  }
  onSendMessage() {
    this.signalrClientService.sendMessage(this.userReceiver.name, this.userSender.name, this.message).then(res => {
      //this.chatContainer.push({ message: this.message, sender: this.signalrClientService.userName, receiver: this.signalrClientService.userName, isSender: true })
    });
  }
  onSelectReceiver(user: ChatUser) {
    this.userReceiver=user;
    // if (this.userReceiver.name == 'Everyone') {
    //   this.userReceiver = user;
    // } else if (this.userReceiver.name == user.name) {
    //   this.userReceiver = this.defaultReceiver;
    // } else {
    //   this.userReceiver = user;
    // }
  }

}
