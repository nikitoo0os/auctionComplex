import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
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
  // submitForm() {
  //   throw new Error('Method not implemented.');
  // }

  listOfMyAuctionItems: any;
  listOfChildrenData: ChildrenItemData[] = [];
  listOfWallets: any;
  accountStatus: string | undefined;
  inputAddress!: '';
  walletForm!: FormGroup;
  statusValidate: any;
  isMyItems!: boolean;

  constructor(
    private userService: UserService,
    private auctionItemService: AuctionItemService,
    private walletService: WalletService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  firstName: string | undefined;
  secondName: string | undefined;
  username: string | undefined;
  status: boolean = false;
  isDisabledBtn!: boolean;
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
              this.isMyItems = true;
              this.listOfMyAuctionItems = data.reverse();
            });

          this.walletService.getWalletByUserId(this.user.id).then((data) => {
            this.listOfWallets = data;
            console.log('КОШЕЛЬКИ', this.listOfWallets);
          });
        });
      }
    } else {
      this.isUserProfile = false;
      this.isMyItems = false;
      const auctioneerId = Number(userProfileid);
      this.userService.getUserById(auctioneerId).then((data) => {
        this.user = data;
        this.auctionItemService
          .getAuctionItemsByAuctioneer(auctioneerId)
          .then((data) => {
            this.listOfMyAuctionItems = data;
          });
      });
    }

    this.walletForm = this.formBuilder.group({
      address: ['', Validators.required],
      confirmCode: ['', Validators.required],
      token: [],
    });
  }

  isVisible = false;
  isOkLoading = false;

  showModal(): void {
    this.walletService.createConfirmCode();
    this.isVisible = true;
  }

  handleOk(): void {
    if(this.walletForm.value['address'].length == 48){
      this.walletForm.value['token'] = this.token;
      this.isOkLoading = true;
      console.log(this.walletForm);
      setTimeout(() => {
        this.walletService
          .createWalletByAddressAndUserId(this.walletForm.value)
          .then((data) => {
            this.listOfWallets.push(data);
            this.isVisible = false;
            this.isOkLoading = false;
          });
      }, 3000);
    }

  }

  handleCancel(): void {
    this.isVisible = false;
  }

  dropWallet(idWallet: number) {
    this.walletService.dropWalletByIdWallet({
      id: idWallet,
      token: this.token,
    });

    const indexToRemove = this.listOfWallets.findIndex(
      (wallet: { id: any }) => wallet.id === idWallet
    );

    if (indexToRemove !== -1) {
      this.listOfWallets.splice(indexToRemove, 1);
    }
  }

  OnInputChange() {
    this.statusValidate = "validating"
    if(this.walletForm.value['address'].length != 48){
      this.statusValidate = "error";
    }
    else{
      this.statusValidate = "success";
    }
  }
}
