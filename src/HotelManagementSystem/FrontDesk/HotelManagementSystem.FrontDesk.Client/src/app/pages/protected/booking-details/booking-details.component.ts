import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from '../services/booking.service';
import { Booking } from '../models/booking';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ReasonModalComponent } from '../reason-modal/reason-modal.component';
import { Room } from '../models/room';
import { RoomService } from '../services/room.service';

@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit {
  booking: Booking;
  rooms: Room[];

  constructor(private route: ActivatedRoute, private bookingService: BookingService, private roomService: RoomService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.getBookingDetails();
  }

  getBookingDetails(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.bookingService.getBooking(id)
      .subscribe(booking => {
        this.booking = booking;
        this.loadAvailableRooms(booking.roomType.id);
      });
  }
      loadAvailableRooms(roomTypeId: number): void {
        this.roomService.getAvailableRooms(roomTypeId)
          .subscribe(rooms => this.rooms = rooms);
    }

      declineBooking(): void {
        const modalRef = this.modalService.open(ReasonModalComponent);
        modalRef.componentInstance.bookingId = this.booking.id;
        modalRef.result.then((reason) => {
          // Call API to decline booking with reason
          this.bookingService.declineBooking(this.booking.id, reason)
            .subscribe(response => {
            });
        }, () => {
        });
      }
      acceptBooking(): void {
      }
}