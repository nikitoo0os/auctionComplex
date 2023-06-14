import { Component, OnInit } from '@angular/core';
import { AuctionItemService } from 'src/app/services/api/auction-item.service';
import { UserService } from 'src/app/services/api/user.service';
import { setCookie } from 'src/app/utils/cookie-utils';

interface AuctionItemData {
  id: number;
  title: string;
  description: string;
  investmentSize: number;
  category: string;
  startDate: String;
  endDate: String;
  location: string;
}

interface ChildrenItemData {
  id: number;
  investmentVolume: number;
  entryPercentage: number;
  timestamp: string;
  userId: number;
}

@Component({
  selector: 'app-auction-items',
  templateUrl: './auction-items.component.html',
})
export class AuctionItemsComponent implements OnInit {
  selectedValue = 'Категория сферы';
  listOfGroupOption = [
    { label: 'Строительство', value: 'строительство', groupLabel: 'Manager' },
    { label: 'Строительство', value: 'строительство', groupLabel: 'Manager' },
    { label: 'Строительство', value: 'строительство', groupLabel: 'Manager' },
  ];

  listOfAuctionItem: any ;
  listOfChildrenData: ChildrenItemData[] = [];
  auctionItem: any;

  constructor(
    private userService: UserService,
    private auctionItemService: AuctionItemService
  ) {}

  ngOnInit(): void {
    this.auctionItemService.getData().then((data) => {
      this.listOfAuctionItem = data;
      console.log('СПИСОК');
      console.log(this.listOfAuctionItem);
    });
  }

  sendPostReq(auctionItemId: number){
    this.auctionItemService.getAuctionItemById(auctionItemId).then((data) => {
      this.auctionItem = data;
      setCookie('auctionItem', this.auctionItem);
      console.log(this.auctionItem);
    });
  }
}
