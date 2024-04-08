import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BookingDetailsComponent } from './booking-details.component';
import { RouterModule } from '@angular/router';


describe('BookingDetailsComponent', () => {
  let component: BookingDetailsComponent;
  let fixture: ComponentFixture<BookingDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BookingDetailsComponent],
      imports: [RouterModule.forRoot([])] // Add RouterModule to imports array
    }).compileComponents();

    fixture = TestBed.createComponent(BookingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});