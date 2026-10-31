import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarPage } from './car.page';

describe('CarPage', () => {
  let component: CarPage;
  let fixture: ComponentFixture<CarPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarPage],
    }).compileComponents();

    fixture = TestBed.createComponent(CarPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
