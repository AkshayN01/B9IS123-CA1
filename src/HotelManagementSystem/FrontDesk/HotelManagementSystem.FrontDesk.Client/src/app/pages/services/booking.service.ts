import { Injectable } from '@angular/core';
import { Booking } from '../models/booking.model';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor() {}

  getAllBookings(): Observable<Booking[]> {

  const bookings: Booking[] = [
    {
      id: 1,
      fromDate: "2024-04-10",
      toDate: "2024-04-15",
      branchId: 1,
      visitorDetails: {
        visitorId: 1,
        firstName: "John",
        middleName: "",
        lastName: "Doe",
        emailId: "john@example.com",
        phoneNo: "1234567890",
        isPrimary: 1
    }
  }
    
  ];
    return of(bookings);
}
}


