import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ReasonModalComponent } from '../reason-modal/reason-modal.component';
import { RoomAssignmentDialogComponent } from '../room-assignment-dialog/room-assignment-dialog.component';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from '../../../services/booking/booking.service';
import { ResponseHandlerService } from '../../../services/shared/resposne/resposne-handler.service';
import { RoomService } from '../../../services/room/room.service';

@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit {
  id!:string;
  bookingDetails: any;
  availableRooms!: any[];
  roomSelected: boolean = false;
  primaryVisitor: any;
  travelPartner: any[] =[];
  showAcceptDeclineButtons: boolean = true;
  
  
  constructor(private dialog: MatDialog, private bookingService: BookingService, private roomService: RoomService, private route: ActivatedRoute, private responseHandler: ResponseHandlerService) 
  {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      // Use this.id as needed in your component
      this.fetchBookingDetails();
    });
  }

  fetchBookingDetails()
  {
    this.bookingService.getBookingDetails(this.id).subscribe(res => {
      this.bookingDetails = this.responseHandler.checkResponse(res);
      this.primaryVisitor = this.bookingDetails.visitors.find((visitor: any) => visitor.isPrimary == 1);
      this.travelPartner = this.bookingDetails.visitors.filter((visitor: any) => visitor.isPrimary == 0);
    });
  }


  acceptBooking() {
    this.roomService.getAllRooms(this.bookingDetails.roomType.id)
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

    
    // this.roomService.assignRoom(this.bookingDetails.roomDetails)
    //   .subscribe((response: any) => {
    //   });

    this.roomSelected = true;
  }

  declineBooking() {
    const dialogRef = this.dialog.open(ReasonModalComponent, {
      width: '300px',
      data: { reason: '' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {

        // this.room.declineBooking(this.bookingDetails.id, result)
        //   .subscribe((response: any) => {
           
        //   });
      }
    });
  }
}

