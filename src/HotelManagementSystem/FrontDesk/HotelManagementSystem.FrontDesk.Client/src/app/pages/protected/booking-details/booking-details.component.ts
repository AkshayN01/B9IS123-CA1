import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ReasonModalComponent } from '../reason-modal/reason-modal.component';
import { RoomService } from '../services/room.service';

@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit {
  bookingDetails: any;
  availableRooms!: any[];
  roomSelected: boolean = false;

  constructor(private dialog: MatDialog, private room: RoomService) { }

  ngOnInit() {
    this.fetchBookingDetails();
  }

  fetchBookingDetails() {
  }

  acceptBooking() {
    this.room.getAvailableRooms(this.bookingDetails.roomType.id)
      .subscribe(response => {
        this.availableRooms = response;
      });
  }

  selectRoom(roomId: number) {
    this.bookingDetails.roomDetails = {
      branchId: this.bookingDetails.branchId,
      bookingId: this.bookingDetails.id,
      requestStatus: 'Accepted',
      roomId: roomId
    };

    
    this.room.assignRoom(this.bookingDetails.roomDetails)
      .subscribe(response => {
      });

    this.roomSelected = true;
  }

  declineBooking() {
    const dialogRef = this.dialog.open(ReasonModalComponent, {
      width: '400px',
      data: { reason: '' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {

        this.room.declineBooking(this.bookingDetails.id, result)
          .subscribe(response => {
           
          });
      }
    });
  }
}
