import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-booking-register',
  templateUrl: './booking-register.component.html',
  styleUrls: ['./booking-register.component.css']
})
export class BookingRegisterComponent {
    bookingForm: FormGroup;
  
    constructor(private formBuilder: FormBuilder) {
      this.bookingForm = this.formBuilder.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        checkInDate: ['', Validators.required],
        checkOutDate: ['', Validators.required]
      });
    }
  
    