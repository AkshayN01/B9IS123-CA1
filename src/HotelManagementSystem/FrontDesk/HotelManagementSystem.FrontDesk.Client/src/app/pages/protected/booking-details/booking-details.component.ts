import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ReasonModalComponent } from '../reason-modal/reason-modal.component';
import { RoomService } from '../../services/room.service';
import { RoomAssignmentDialogComponent } from '../room-assignment-dialog/room-assignment-dialog.component';

@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit {
  bookingDetails: any;
  availableRooms!: any[];
  roomSelected: boolean = false;
  primaryVisitor: any;
  travelPartner: any[] =[];
  showAcceptDeclineButtons: boolean = true;
  
  
  constructor(private dialog: MatDialog, private room: RoomService) 
  {
   }

  ngOnInit() {
    this.fetchBookingDetails();
  }

  fetchBookingDetails()
  {
    this.bookingDetails={
  "id": 0,
  "fromDate": "0001-01-01T00:00:00",
  "toDate": "0001-01-01T00:00:00",
  "branchId": 0,
  "room": [
    {
      "id": 1,
      "level": 1,
      "roomNumber": 101,
      "roomName": "101",
      "roomTypeId": 0,
      "roomType": {
        "id": 4,
        "name": "Dormitory",
        "price": 60,
        "maxCapacity": 8
      }
    }
  ],
  "visitors": [
    {
      "id": 15,
      "firstName": "Akshay",
      "middleName": "Mohanan",
      "lastName": "Nambly",
      "email": "test1@test.com",
      "phone": "1234567",
      "isPrimary": 1
    },
    {
      "id": 16,
      "firstName": "Abhiram",
      "middleName": "Mohanan",
      "lastName": "Nambly",
      "email": null,
      "phone": null,
      "isPrimary": 0
    },
    {
      "id": 17,
      "firstName": "Mohanan",
      "middleName": "Kumaran",
      "lastName": "Nambly",
      "email": null,
      "phone": null,
      "isPrimary": 0
    },
    {
      "id": 18,
      "firstName": "Sudha",
      "middleName": "Mohanan",
      "lastName": "Nambly",
      "email": null,
      "phone": null,
      "isPrimary": 0
    }
  ]
}
this.primaryVisitor = this.bookingDetails.visitors.find((visitor: any) => visitor.isPrimary);
this.travelPartner = this.bookingDetails.visitors.filter((visitor: any) => !visitor.isPrimary);
}


  acceptBooking() {
    this.room.getAvailableRooms(this.bookingDetails.roomType.id)
      .subscribe((response: any) => {
        this.availableRooms = response;
        this.openRoomAssignmentDialog();
      });
  }

  openRoomAssignmentDialog() {
    const dialogRef = this.dialog.open(RoomAssignmentDialogComponent, {
      width: '300px',
      data: { availableRooms: this.availableRooms }
    });

    dialogRef.afterClosed().subscribe((selectedRoomId: number) => {
      if (selectedRoomId) {
        this.selectRoom(selectedRoomId);
      }
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
      .subscribe((response: any) => {
      });

    this.roomSelected = true;
  }

  declineBooking() {
    const dialogRef = this.dialog.open(ReasonModalComponent, {
      width: '300px',
      data: { reason: '' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {

        this.room.declineBooking(this.bookingDetails.id, result)
          .subscribe((response: any) => {
           
          });
      }
    });
  }
}

