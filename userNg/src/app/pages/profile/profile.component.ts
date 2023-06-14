import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuctionItemService } from 'src/app/services/api/auction-item.service';
import { UserService } from 'src/app/services/api/user.service';
import { WalletService } from 'src/app/services/api/wallet.service';

interface AuctionItemData {
  id: number;
  title: string;
  description: string;
  investmentSize: number;
  startDate: String;
  endDate: String;
  winnerId: number | null;
  auctioneerId: number;
  location: string;
  expand: boolean;
}

interface ChildrenItemData {
  id: number;
  investmentVolume: number;
  entryPercentage: number;
  timestamp: string;
  userId: number;
}

interface ParentWalletData {
  id: number;
  address: string;
  balance: number;
  expand: boolean;
}

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  listOfMyAuctionItems: any;
  listOfChildrenData: ChildrenItemData[] = [];
  listOfWallets: any;
  accountStatus: string | undefined;

  constructor(
    private userService: UserService,
    private auctionItemService: AuctionItemService,
    private walletService: WalletService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  firstName: string | undefined;
  secondName: string | undefined;
  username: string | undefined;
  status: boolean = false;
  user: any;
  isUserProfile!: boolean;
  token: any;

  ngOnInit(): void {
    const userProfileid = this.route.snapshot.paramMap.get('id');

    if (userProfileid == null) {
      this.token = localStorage.getItem('token');
      console.log('wiseosjfgnuiwerfuihw3fuiweofhuiwe');
      console.log(this.token);
      if (this.token == null) {
        this.router.navigateByUrl('/login');
      } else {
        console.log('ОТПРАВКА ТОКЕНА!');

        this.userService.getUserByToken(this.token).then((data: any) => {
          this.user = data;
          console.log(this.user);

          this.auctionItemService
            .getAuctionItemsByAuctioneer(this.user.id)
            .then((data) => {
              console.log('ЛОТЫ ПОЛЬЗОВАТЕЛЯ:: ', data);
              this.listOfMyAuctionItems = data;
            });

          this.walletService.getWalletByUserId(this.user.id).then((data) => {
            this.listOfWallets = data;
            console.log('КОШЕЛЬКИ', this.listOfWallets);
          });
        });
      }
    } else {
      this.isUserProfile = false;
      const auctioneerId = Number(userProfileid);
      this.userService.getUserById(auctioneerId).then((data) => {
        this.user = data;
        this.auctionItemService.getAuctionItemsByAuctioneer(auctioneerId).then((data) => {
          this.listOfMyAuctionItems = data;
        })
      })
    }
  }
}
