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

  listOfTime = [
    { label: 'На этой неделе', value: '1 week', groupLabel: '' },
    { label: 'В этом месяце', value: '1 month', groupLabel: '' },
    { label: 'Ранее', value: null, groupLabel: '' },
  ];

  listOfInvestmentVolume = [
    { label: 'до 10 000 TON', value: '10000', groupLabel: '' },
    { label: 'до 50 000 TON', value: '50000', groupLabel: '' },
    { label: 'от 50 000 TON', value: null, groupLabel: '' },
  ];

  listOfAuctionItem: any;
  listOfChildrenData: ChildrenItemData[] = [];
  auctionItem: any;
  categories: any;

  selectedInvestmentVolume: any = null;
  selectedCategory: any = null;
  selectedTime: any = null;

  constructor(
    private userService: UserService,
    private auctionItemService: AuctionItemService
  ) {}

  convertToGroupOption(categoryData: string[]): any[] {
    const listOfGroupOption: any[] = [];

    for (let category of categoryData) {
      listOfGroupOption.push({
        label: category,
        value: category,
        groupLabel: '',
      });
    }

    return listOfGroupOption;
  }

  ngOnInit(): void {
    this.auctionItemService.getData().then((data) => {
      this.listOfAuctionItem = data;
      console.log('СПИСОК');
    });

    this.auctionItemService.getAllCategories().then((data) => {
      this.categories = data;
      this.categories = this.convertToGroupOption(this.categories);
    });
  }

  sendPostReq(auctionItemId: number) {
    this.auctionItemService.getAuctionItemById(auctionItemId).then((data) => {
      this.auctionItem = data;
      setCookie('auctionItem', this.auctionItem);
      console.log(this.auctionItem);
    });
  }

  handleDelayedRequest(): void {
    const filter = {
      investmentVolume: this.selectedInvestmentVolume,
      time: this.selectedTime,
      category: this.selectedCategory,
    };
    console.log('ФИЛЬТР', filter);
    this.auctionItemService.getFilterAuctionItem(filter).then((data) => {
      console.log('ОТФИЛЬТР аук', data);
    });
  }
}
