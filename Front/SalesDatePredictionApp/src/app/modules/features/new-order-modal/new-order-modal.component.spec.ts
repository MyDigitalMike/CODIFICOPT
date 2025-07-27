import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewOrderModalComponent } from './new-order-modal.component';

describe('NewOrderModalComponent', () => {
  let component: NewOrderModalComponent;
  let fixture: ComponentFixture<NewOrderModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewOrderModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewOrderModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
