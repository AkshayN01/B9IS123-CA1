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
  pagedBookings: Booking[] = [];
  pageSize = 10;
  fromDate: string | null = null;
  toDate: string | null = null;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.bookings = [
      {
        id: 0,
        fromDate: "2024-04-21",
        toDate: "2024-04-25",
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
        fromDate: "2024-04-21",
        toDate: "2024-04-25",
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
      },
      {
        id: 3,
        fromDate: "2024-04-26",
        toDate: "2024-04-30",
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
      }
    ];

    console.log(this.bookings)
   this.applyFilter();
  }


  viewBooking(bookingId: number): void {
    this.router.navigate(['/booking', bookingId]);
  }

  onPageChange(event: any): void {
    const startIndex = event.pageIndex * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.pagedBookings = this.bookings.slice(startIndex, endIndex);
  }

  applyFilter(): void {
    this.pagedBookings = this.bookings.filter(booking => {
      let fromDateMatch = true;
      let toDateMatch = true;

      if (this.fromDate && new Date(booking.fromDate) < new Date(this.fromDate)) {
        fromDateMatch = false;
      }

      if (this.toDate && new Date(booking.toDate) > new Date(this.toDate)) {
        toDateMatch = false;
      }

      return fromDateMatch && toDateMatch;
    });
  }
}