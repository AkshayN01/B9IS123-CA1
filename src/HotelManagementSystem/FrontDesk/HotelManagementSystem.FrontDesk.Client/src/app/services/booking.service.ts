import { Injectable } from '@angular/core';
import { Booking } from '../booking.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private bookings: Booking[] = [
    { id: 1, name: 'Booking 1', date: new Data() },
    { id: 2, name: 'Booking 2', data: new Data() },
  ];
  getAllBookings(): Booking[] [
    return this.bookings;
  ]
}


