import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReserverenComponent } from './reserveren.component';

describe('ReserverenComponent', () => {
  let component: ReserverenComponent;
  let fixture: ComponentFixture<ReserverenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReserverenComponent]
    });
    fixture = TestBed.createComponent(ReserverenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
