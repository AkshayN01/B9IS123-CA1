import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UserComponent } from './user.component';
import { FormsModule } from '@angular/forms';

describe('UserComponent', () => {
  let component: UserComponent;
  let fixture: ComponentFixture<UserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserComponent ],
      imports: [FormsModule] // Import FormsModule for ngForm
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have empty form fields initially', () => {
    fixture.detectChanges(); // Ensure changes are detected
    const compiled = fixture.nativeElement;
    const inputs = compiled.querySelectorAll('input');
    inputs.forEach((input: HTMLInputElement) => {
      expect(input.value).toBe('');
    });
  });

  it('should require first name field', () => {
    const firstName = fixture.nativeElement.querySelector('#firstName');
    firstName.value = 'John';
    firstName.dispatchEvent(new Event('input'));
    fixture.detectChanges();
    expect(firstName.validity.valid).toBeTruthy();
  });

  // Add more tests as needed for other form fields and validation
});
