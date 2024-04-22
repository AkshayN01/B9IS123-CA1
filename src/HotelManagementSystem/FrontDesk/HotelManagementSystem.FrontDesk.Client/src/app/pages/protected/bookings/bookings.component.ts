import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from '../../../services/booking/booking.service';
import { ResponseHandlerService } from '../../../services/shared/resposne/resposne-handler.service';
import { Booking } from '../../../models/booking/view-bookings.model';
import { bookingStatus } from '../../../models/booking/booking-status.model';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {
  selectedDate!: Date;
  bookings!: Booking;
  status: string | null =  null;
  pageSize = 10; 
  pageNumber = 1;
  fromDate!: Date;
  toDate!: Date;
  fromDateString!: string;
  toDateString!: string;
  bookingStatuses: any = bookingStatus;

  constructor(private router: Router, private bookingService: BookingService, private responseHandler : ResponseHandlerService) {}

  ngOnInit(): void {
    this.getAllBookings();
    console.log(this.bookings)
    this.applyFilter();
  }

  getAllBookings(): void{
    this.bookingService.viewAllBookings(this.fromDateString, this.toDateString, this.status, this.pageNumber, this.pageSize).subscribe(res => {
      this.bookings = this.responseHandler.checkResponse(res);
    });
  }


  viewBooking(bookingId: number): void {
    this.router.navigate(['/booking-details', bookingId]);
  }

  onPageChange(event: PageEvent): void {
    console.log(event.pageIndex);
    this.pageSize = event.pageSize;
    this.pageNumber = event.pageIndex;
    this.getAllBookings();
  }

  onSelected(value:string):void {
    console.log("Selected")
    console.log(value);
    this.status = value;
	}

  applyFilter(): void {
    console.log("clicked");
    console.log(this.fromDate);
    console.log(this.toDate);
    if(this.fromDate != undefined)
      this.fromDateString = this.convertDate(this.fromDate.toString());
    
    if(this.toDate != undefined)
      this.toDateString = this.convertDate(this.toDate.toString());
    this.getAllBookings();
  }

  convertDate(dateString: string): string {

    // Create a new Date object
    const date = new Date(dateString);

    // Get the day, month, and year components
    const day = ("0" + date.getDate()).slice(-2); // Zero padding
    const month = ("0" + (date.getMonth() + 1)).slice(-2); // Months are zero-based
    const year = date.getFullYear();

    // Get the hours, minutes, and seconds components
    const hours = ("0" + date.getHours()).slice(-2);
    const minutes = ("0" + date.getMinutes()).slice(-2);
    const seconds = ("0" + date.getSeconds()).slice(-2);

    // Format the date in the desired format
    const formattedDate = `${day}/${month}/${year} ${hours}:${minutes}:${seconds}`;

    console.log(formattedDate); // Output: "01/04/2024 00:00:00"

    return formattedDate;
  }
}