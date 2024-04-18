import { Component, OnInit } from '@angular/core';
import { Booking } from '../../models/booking.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {
  bookings: Booking[] = [];

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.bookings = [
      {
        id: 0,
        fromDate: "0001-01-01T00:00:00",
        toDate: "0001-01-01T00:00:00",
        branchId: 0,
        visitorDetails: {
          visitorId: 1,
          firstName: "John",
          middleName: "A",
          lastName: "Doe",
          emailId: "john@example.com",
          phoneNo: "1234567890",
          isPrimary: 1
        }
      },
      {
        id: 2,
        branchId: 1,
        visitorDetails: {
          visitorId: 2,
          firstName: "Jane",
          middleName: "A",
          lastName: "Smith",
          emailId: "jane@example.com",
          phoneNo: "9876543210",
          isPrimary: 1
        },
        fromDate: "2024-04-21",
        toDate: "2024-04-25"
      },
      {
        id: 3,
        branchId: 2,
        visitorDetails: {
          visitorId: 3,
          firstName: "Alice",
          middleName: "A",
          lastName: "Johnson",
          emailId: "alice@example.com",
          phoneNo: "5678901234",
          isPrimary: 1
        },
        fromDate: "2024-04-26",
        toDate: "2024-04-30"
      }
    ];
  }

  viewBooking(bookingId: number): void {
    this.router.navigate(['/booking', bookingId]);
  }
}