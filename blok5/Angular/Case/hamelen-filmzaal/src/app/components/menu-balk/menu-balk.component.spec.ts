import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';  // Add this line
import { MenuBalkComponent } from './menu-balk.component';

describe('MenuBalkComponent', () => {
  let component: MenuBalkComponent;
  let fixture: ComponentFixture<MenuBalkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule],  // Add this line
      declarations: [ MenuBalkComponent ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuBalkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
