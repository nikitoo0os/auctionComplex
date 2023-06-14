import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { AuctionItemsComponent } from './auction-items.component';

describe('AuctionItemsComponent', () => {
  let component: AuctionItemsComponent;
  let fixture: ComponentFixture<AuctionItemsComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AuctionItemsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuctionItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
