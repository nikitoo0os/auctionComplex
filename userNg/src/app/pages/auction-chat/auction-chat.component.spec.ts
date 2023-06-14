import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionChatComponent } from './auction-chat.component';

describe('AuctionChatComponent', () => {
  let component: AuctionChatComponent;
  let fixture: ComponentFixture<AuctionChatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionChatComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuctionChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
