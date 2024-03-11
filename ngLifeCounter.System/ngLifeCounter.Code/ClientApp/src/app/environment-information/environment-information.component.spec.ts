import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnvironmentInformationComponent } from './environment-information.component';

describe('EnvironmentInformationComponent', () => {
  let component: EnvironmentInformationComponent;
  let fixture: ComponentFixture<EnvironmentInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnvironmentInformationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EnvironmentInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
