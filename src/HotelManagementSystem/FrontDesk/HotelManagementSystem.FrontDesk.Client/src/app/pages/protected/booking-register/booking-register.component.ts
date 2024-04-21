import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';
import { RoomService } from '../../../services/room/room.service';
import { ResponseHandlerService } from '../../../services/shared/resposne/resposne-handler.service';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { BookingRegisterModel } from '../../../models/booking/booking-register.model';

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

  constructor(private fb: FormBuilder, private roomService: RoomService, private responseHandler: ResponseHandlerService) {}

  ngOnInit(): void {
    this.getRoomData();
    this.initializeForm();
  }

  getRoomData(): void{
    this.roomService.getRoomTypes().subscribe(response => {
      this.roomTypesData = this.responseHandler.checkResponse(response);
    });
  }

  initializeForm(): void { 
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
  onCheckboxChange(event: MatCheckboxChange): void {
    // event.checked will give you the checked state
    console.log(event.source.value)
    var value = Number(event.source.value);
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
    // if (this.bookingForm.invalid) {
    //   return;
    // }
    
    this.bookingModel = {
      fromDate : this.bookingForm.get('fromDate')?.value,
      toDate: this.bookingForm.get('toDate')?.value,
      roomIds: this.roomIds,
      visitors: []
    }

    this.bookingModel.visitors.push(this.bookingForm.get('primaryVisitor')?.value);
    this.bookingModel.visitors.concat(this.bookingForm.get('partners')?.value)

    console.log(this.bookingModel);
  }
}