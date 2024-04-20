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


  statusFilter: string = '';
  fromDateFilter: Date | null = null;
  toDateFilter: Date | null = null;

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

    console.log(this.bookings)
    this.pagedBookings = this.bookings.slice(0, this.pageSize);
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
      let statusMatch = true;
      let fromDateMatch = true;
      let toDateMatch = true;

      if (this.statusFilter && booking.status !== this.statusFilter) {
        statusMatch = false;

      }

      if (this.fromDateFilter && new Date(booking.fromDate) < this.fromDateFilter) {
        fromDateMatch = false;
      }

      if (this.toDateFilter && new Date(booking.toDate) > this.toDateFilter) {
        toDateMatch = false;
      }

      return statusMatch && fromDateMatch && toDateMatch;
    });
  }
}