import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionItemComponent } from './auction-item.component';

describe('AuctionItemComponent', () => {
  let component: AuctionItemComponent;
  let fixture: ComponentFixture<AuctionItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuctionItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuctionItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
