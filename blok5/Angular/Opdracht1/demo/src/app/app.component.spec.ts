import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component'; 
import { CustomPipe } from './pipes/name-formatter';

describe('AppComponent', () => {
    let component: AppComponent;
    let fixture: ComponentFixture<AppComponent>;
  
    beforeEach(() => {
      TestBed.configureTestingModule({
        declarations: [ AppComponent, CustomPipe ]
      });
  
      fixture = TestBed.createComponent(AppComponent);
      component = fixture.componentInstance;
      fixture.detectChanges();
    });
  
    it('should delete a contact by ID', () => {
      expect(component.contacten.length).toBe(3);
      component.deleteContact(2);
      expect(component.contacten.length).toBe(2);
    });
  
  });
