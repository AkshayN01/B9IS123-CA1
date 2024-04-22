import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';
import { RoomService } from '../../../services/room/room.service';
import { ResponseHandlerService } from '../../../services/shared/resposne/resposne-handler.service';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { BookingRegisterModel } from '../../../models/booking/booking-register.model';
import { BookingService } from '../../../services/booking/booking.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../../../modals/confirmation-dialog/confirmation-dialog.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking-register',
  templateUrl: './booking-register.component.html',
  styleUrls: ['./booking-register.component.css']
})
export class BookingRegisterComponent {

  bookingForm!: FormGroup;
  roomTypesData!: any;
  roomsData!: any;
  loadedRooms: boolean = false;
  roomIds!: Number[];
  bookingModel!: BookingRegisterModel;

  constructor(private fb: FormBuilder, private roomService: RoomService, 
    private responseHandler: ResponseHandlerService, private boojingService: BookingService, 
    private matSnackBar: MatSnackBar, private dialog: MatDialog, private router: Router) {
    this.roomIds = [];
  }

  ngOnInit(): void {
    this.getRoomData();
    this.initializeForm();
  }

  getRoomData(): void{
    this.loadedRooms = false;
    this.roomService.getRoomTypes().subscribe(response => {
      this.roomTypesData = this.responseHandler.checkResponse(response);
    });
  }

  initializeForm(): void { 
    this.roomIds = [];
    this.loadedRooms = false;
    this.bookingForm = this.fb.group({
      fromDate: ['', [Validators.required]],
      toDate: ['', [Validators.required]],
      primaryVisitor: this.fb.group({
        firstName: ['', [Validators.required, Validators.maxLength(50)]], 
        middleName: ['', [Validators.required, Validators.maxLength(50)]], 
        lastName: ['', [Validators.required, Validators.maxLength(50)]], 
        email: ['', [Validators.required, Validators.email]], 
        phone: [0, [Validators.required, Validators.maxLength(10), Validators.minLength(8)]], 
        isPrimary: [1]
      }),
      partners: this.fb.array([]),
    });
  }

  addTravelPartners(): void {
    const travelPartner = this.fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(50)]], 
      middleName: ['', [Validators.required, Validators.maxLength(50)]], 
      lastName: ['', [Validators.required, Validators.maxLength(50)]], 
      email: [''], 
      phone: [''], 
      isPrimary: [0]
    });

    this.partners.push(travelPartner); 
  }

  get partners(): FormArray {
    return this.bookingForm.get('partners') as FormArray;
  }

	onSelected(value:string):void {
    console.log("Selected")
    console.log(value);
    this.getAllAvailableRooms(value);
	}

  getAllAvailableRooms(roomTypeId: string): void{
    this.roomService.getAllRooms(roomTypeId).subscribe(response => {
      this.roomsData = this.responseHandler.checkResponse(response);
      this.loadedRooms = true;
      console.log(this.roomsData);
    });
  }
  onCheckboxChange(event: MatCheckboxChange, room : any): void {
    // event.checked will give you the checked state
    console.log(room)
    var value = Number(room.id);

    if(event.checked){
      this.roomIds.push(value);
    }
    else{
      var index = this.roomIds.indexOf(value);
      if (index !== -1) {
        this.roomIds.splice(index, 1);
      }
    }
  }
  

  onSubmit() {
    if (this.bookingForm.invalid || this.roomIds.length == 0) {
      return;
    }
    
    this.bookingModel = {
      fromDate : this.bookingForm.get('fromDate')?.value,
      toDate: this.bookingForm.get('toDate')?.value,
      roomIds: this.roomIds,
      visitors: []
    }

    this.bookingModel.visitors.push(this.bookingForm.get('primaryVisitor')?.value);
    console.log(this.bookingForm.get('partners')?.value)
    this.bookingModel.visitors = this.bookingModel.visitors.concat(this.bookingForm.get('partners')?.value)
    this.bookingModel.fromDate = this.convertDate(this.bookingModel.fromDate);
    this.bookingModel.toDate = this.convertDate(this.bookingModel.toDate);
    console.log(this.bookingModel);

    this.boojingService.addBooking(this.bookingModel).subscribe(res => {
      var response = this.responseHandler.checkResponse(res);
      if(response.bookingId != 0){
        this.openConfirmationDialog();
      }
    })
  }

  openConfirmationDialog(): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '300px',
      data: { title: 'Confirmation', message: 'Do you want to add another booking?' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.initializeForm();
      } else {
        this.router.navigate(['/all-bookings']);
      }
    });
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