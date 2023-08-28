import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DienstenComponent } from './diensten.component';

describe('DienstenComponent', () => {
  let component: DienstenComponent;
  let fixture: ComponentFixture<DienstenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DienstenComponent]
    });
    fixture = TestBed.createComponent(DienstenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
