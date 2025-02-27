import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RewardCoinComponent } from './reward-coin.component';

describe('RewardCoinComponent', () => {
  let component: RewardCoinComponent;
  let fixture: ComponentFixture<RewardCoinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RewardCoinComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RewardCoinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
