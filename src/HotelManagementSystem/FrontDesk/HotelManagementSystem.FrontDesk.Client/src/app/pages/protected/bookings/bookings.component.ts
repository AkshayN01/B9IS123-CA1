import { Component, OnInit } from '@angular/core';
import { Booking } from '../../models/booking.model';
import { BookingService } from '../../services/booking.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {
  bookings: Booking[] = [];

  constructor(private bookingService: BookingService, private router: Router) {}

  ngOnInit(): void {
    this.loadBookings();
  }

  loadBookings(): void {
    this.bookingService.getAllBookings().subscribe(bookings => {
      this.bookings = bookings;
    });
  }

  viewBooking(bookingId: number): void {
        this.router.navigate(['/booking', bookingId]);
  }
}