import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EvenementPageComponent } from './evenement-page.component';

describe('EvenementPageComponent', () => {
  let component: EvenementPageComponent;
  let fixture: ComponentFixture<EvenementPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EvenementPageComponent]
    });
    fixture = TestBed.createComponent(EvenementPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
