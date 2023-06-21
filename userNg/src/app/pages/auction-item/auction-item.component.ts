import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { AttachmentService } from 'src/app/services/api/attachment.service';
import { AuctionChatService } from 'src/app/services/api/auction-chat.service';
import { AuctionItemService } from 'src/app/services/api/auction-item.service';
import { getCookie } from 'src/app/utils/cookie-utils';

interface AuctionItemData {
  isValid: string;
  id: number;
  title: string;
  description: string;
  investmentSize: number;
  category: string;
  startDate: string;
  endDate: string;
  location: string;
}
interface AttachmentData {
  id: number;
  key: string;
  fileSize: string;
  fileType: string;
  name: string;
}

@Component({
  selector: 'app-auction-item',
  templateUrl: './auction-item.component.html',
  styleUrls: ['./auction-item.component.scss'],
})
export class AuctionItemComponent implements OnInit {
  itemId: string | null | undefined;
  attachments: AttachmentData[] = [];
  auctionItem!: AuctionItemData;
  currentTime!: Date;
  endDate!: Date;
  deadline!: number;
  status!: boolean;
  attachmentLink!: string;

  constructor(
    private auctionItemService: AuctionItemService,
    private attachmentService: AttachmentService,
    private auctionChatService: AuctionChatService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.itemId = this.route.snapshot.paramMap.get('id');
    console.log('Item ID:', this.itemId);

    this.auctionItemService
      .getAuctionItemById(Number(this.itemId))
      .then((data) => {
        this.auctionItem = data;
        console.log(this.auctionItem);
        this.getAttachmentData(this.auctionItem.id);
        this.endDate = new Date(this.auctionItem.endDate);

        console.log(this.auctionItem.isValid);
        if(this.auctionItem.isValid == 'completed'){
          this.status = false;
        }
        else{
          this.status = true;
        }

      });

    setInterval(() => {
      this.deadline = this.endDate.getTime();
    }, 1000);
  }

  getAttachmentData(itemId: number) {
    this.attachmentService
      .getAttachmentsByAuctionItemId(this.auctionItem.id)
      .then((data) => {
        this.attachments = data;
        console.log(this.attachments);
      })
      .catch((err) => {
        console.log(err);
      });
  }

  downloadAttachmentById(attachmentId: number) {
    this.attachmentService.getAttachmentsById(attachmentId);
  }

}
