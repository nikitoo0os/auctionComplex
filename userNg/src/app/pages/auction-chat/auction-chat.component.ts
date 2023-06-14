import { Component, OnInit } from '@angular/core';
import { MentionOnSearchTypes } from 'ng-zorro-antd/mention';
import { formatDistance } from 'date-fns';
import { ActivatedRoute } from '@angular/router';
import { BidService } from 'src/app/services/api/bid.service';
import * as SockJS from 'sockjs-client';
import { IMessage, Stomp } from '@stomp/stompjs';
import { Observable, Subject, debounceTime, empty } from 'rxjs';
import { WebsocketService } from 'src/app/services/api/websocket.service';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { AuctionChatService } from 'src/app/services/api/auction-chat.service';
import { UserService } from 'src/app/services/api/user.service';
import { WalletService } from 'src/app/services/api/wallet.service';

interface DataBid {
  id: number;
  investmentVolume: number;
  entryPercentage: number;
  timestamp: Date;
  firstNameUser: string;
}
interface auctionChatData {
  id: number;
}
interface chatMessageData {
  id: number | null;
  text: string;
  auctionChatId: string;
  userId: number;
  firstName: string;
  secondName: string;
  attachmentId: number | null;
  timestamp: string;
}
interface userData{
  id: number | null;
  firstName: string;
  secondName: string;
  username: string;
  isVerify: boolean;
}

@Component({
  selector: 'app-auction-chat',
  templateUrl: './auction-chat.component.html',
  styleUrls: ['./auction-chat.component.scss'],
})
export class AuctionChatComponent implements OnInit {
  private stompClient: any;
  userWallet: any;
  private updateValidatorSubject = new Subject<void>();

  
  constructor(
    private fb: UntypedFormBuilder,
    private auctionChatService: AuctionChatService,
    private bidService: BidService,
    private userService: UserService,
    private walletService: WalletService,
    private route: ActivatedRoute,
    private webSocketService: WebsocketService
  ) 
  {
    this.bidForm = this.fb.group({
      investmentVolume: ['', Validators.required],
      entryPercentage: ['', Validators.required]
    });

    this.updateValidatorSubject.pipe(debounceTime(1000)).subscribe(() => {
      this.UpdateValidator();
    });
  }

  bidForm!: UntypedFormGroup;
  statusValidate: string = "";

  itemId!: string | null;
  auctionChat!: auctionChatData;
  chatMessages: chatMessageData[] = [];
  private chatMessage!: chatMessageData;
  messages: any[] = [];
  inputMessage!: string;
  bids: DataBid[] = [];
  receivedMessages: string[] = [];
  userId: number = 3;
  user!: any;

  investmentVolume!: number | null;
  entryPercentage!: number | null;

  ngOnInit(): void {
    this.itemId = this.route.snapshot.paramMap.get('id');
    console.log('Item ID:', this.itemId);

    console.log("USER:::");
    this.userService.getUserById(this.userId).then((data) => {
      this.user = data;
      console.log(data);
    });
    

    this.webSocketService.connectChat(this.itemId!).subscribe((data) => {
      this.messages = data;
      console.log('Получено смс::::')
      console.log(data);
    });

    this.auctionChatService
      .getAuctionChatByAuctionId(Number(this.itemId))
      .then((res) => {
        console.log(res);
        this.auctionChat = res.data;
      })
      .catch((err) => {
        console.log(err);
      });

    this.auctionChatService
      .getChatMessagesByAuctionId(Number(this.itemId))
      .then((res) => {
        console.log(res);
        this.chatMessages = res.data;
      })
      .catch((err) => {
        console.log(err);
      });

    this.bidService
      .getBidsByAuctionItemId(Number(this.itemId))
      .then((res) => {
        console.log(res);
        this.bids = res.data;
      })
      .catch((err) => {
        console.log(err);
      });
  }

  index1 = 0;
  index2 = 0;

  inputValue?: string;
  loading = false;
  suggestions: string[] = [];

  onSearchChange({ value }: MentionOnSearchTypes): void {
    console.log(`search: ${value}`);
    this.loading = true;
    this.fetchSuggestions(value, (suggestions) => {
      console.log(suggestions);
      this.suggestions = suggestions;
      this.loading = false;
    });
  }

  fetchSuggestions(
    value: string,
    callback: (suggestions: string[]) => void
  ): void {
    const users = [
      'afc163',
      'benjycui',
      'yiminghe',
      'jljsj33',
      'dqaria',
      'RaoHai',
    ];
    setTimeout(
      () => callback(users.filter((item) => item.indexOf(value) !== -1)),
      500
    );
  }

  likes = 0;
  dislikes = 0;
  time = formatDistance(new Date(), new Date());

  like(): void {
    this.likes = 1;
    this.dislikes = 0;
  }

  dislike(): void {
    this.likes = 0;
    this.dislikes = 1;
  }

  listOfColumn = [
    {
      title: 'Идентификатор ставки',
      compare: (a: DataBid, b: DataBid) => a.id - b.id,
      priority: false,
    },
    {
      title: 'Имя участника',
      compare: (a: DataBid, b: DataBid) =>
        a.firstNameUser.localeCompare(b.firstNameUser),
      priority: false,
    },
    {
      title: 'Размер инвестиций(TON)',
      compare: (a: DataBid, b: DataBid) =>
        a.investmentVolume - b.investmentVolume,
      priority: 3,
    },
    {
      title: 'Процент входа в капитал',
      compare: (a: DataBid, b: DataBid) =>
        a.entryPercentage - b.entryPercentage,
      priority: 2,
    },
  ];

  OnInputChange() {
    this.statusValidate = "validating"
    if(this.investmentVolume == null){
      this.statusValidate = "";
    }
    this.updateValidatorSubject.next();
  }

  UpdateValidator(){
    //console.log(this.userService.getUserById(this.userId));
    this.walletService.getWalletByUserId(this.userId).then((data) => {
      this.userWallet = data;
      console.log(this.userWallet);
      if(this.investmentVolume! <= this.userWallet.balance){
        this.statusValidate = "success";
        if(this.investmentVolume == null){
          this.statusValidate = "";
        }
      }
      else{
        this.statusValidate = "error";
      }
    })

  }

  OnSendBid(){
    this.OnSendMessage();
  }

  OnSendMessage() {
    this.chatMessages = [];

    
    if(this.bidForm.valid){
      const chatMessage: chatMessageData = {
        id: null,
        text: `Готов вложить ${this.investmentVolume} TON и получить ${this.entryPercentage}% долю в капитале компании`,
        auctionChatId: this.itemId!,
        userId: this.userId,
        attachmentId: 0,
        timestamp: Date(),
        firstName: this.user.firstName,
        secondName: this.user.secondName
      };
      this.webSocketService.sendMessage(this.itemId!, chatMessage.text, this.userId);
      console.log(chatMessage);
      this.chatMessages.push(chatMessage);
    }
    else{
      console.log("Проверьте правильность введенных данных");
    }

    this.investmentVolume = null;
    this.entryPercentage = null;

  }
}
